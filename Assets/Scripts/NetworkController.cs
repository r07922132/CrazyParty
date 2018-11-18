using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NetworkController : NetworkManager
{
    string sceneName;
    int[] roles = new int[4];

    object countLock = new object();
    int roleCount = 0;
    int clientCount = 0;

    void Start()
    {
        for (int i = 0; i < roles.Length; i++)
            roles[i] = i;
    }

    static void Shuffle(int[] arr)  // How the hell is this not in the standard library??
    {
        var rng = new System.Random();
        int n = arr.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            int tmp = arr[n];
            arr[n] = arr[k];
            arr[k] = tmp;
        }
    }

    public override void OnServerConnect(NetworkConnection conn)
    {
        base.OnServerConnect(conn);
        lock (countLock)
        {
            clientCount++;
        }
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        base.OnServerDisconnect(conn);
        lock (countLock)
        {
            clientCount--;
        }
    }

    public override void OnServerSceneChanged(string s)
    {
        sceneName = s;

        roleCount = 0;
        Shuffle(roles);
        base.OnServerSceneChanged(s);
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short id)
    {
        var gos = SceneManager.GetSceneByName(sceneName).GetRootGameObjects();
        var sl = System.Array.Find(gos, x => x.name.Equals("SceneLoader"));
        if (sl == null)
            Debug.LogError("Scene doesn't contain a SceneLoader game object");

        var loader = (SceneLoader)sl.GetComponent(typeof(SceneLoader));
        if (loader == null)
        {
            Debug.LogError("Game object doesn't contain a SceneLoader script");
            StartCoroutine(SpawnOnClientsReady(conn, playerPrefab, id, -1));
        }
        else
        {
            int i;
            lock (countLock)
            {
                i = roleCount++;
            }
            var playerPrefab = loader.playerPrefabs[roles[i]];
            StartCoroutine(SpawnOnClientsReady(conn, playerPrefab, id, i));
        }
    }

    IEnumerator SpawnOnClientsReady(NetworkConnection conn, GameObject playerPrefab, short id, int role)
    {
        while (true)
        {
            lock (countLock)
            {
                if (roleCount >= clientCount)
                    break;
            }
            yield return null;
        }

        Debug.Log("clientCount = " + clientCount.ToString());

        var player = (GameObject)GameObject.Instantiate(playerPrefab);
        NetworkServer.AddPlayerForConnection(conn, player, id);

        var cb = (PlayerBehaviour)player.GetComponent(typeof(PlayerBehaviour));
        cb.RpcSetRole(role);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SceneLoader : NetworkBehaviour {

    public GameObject[] playerPrefabs = new GameObject[4];
    public List<GameObject> spawnablePrefabs = new List<GameObject>();

    void Start()
    {
        foreach (var p in playerPrefabs)
        {
            if (p.GetComponent(typeof(PlayerBehaviour)))
                ClientScene.RegisterPrefab(p);
            else
            {
                Debug.LogError("Player prefab required to have PlayerBehaviour");
                Bug.Splat();
            }
        }

        foreach (var s in spawnablePrefabs)
            ClientScene.RegisterPrefab(s);

        ClientScene.AddPlayer(connectionToServer, 0);
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;
    }

    void OnDestroy()
    {
        foreach (var p in playerPrefabs)
            ClientScene.UnregisterPrefab(p);

        foreach (var s in spawnablePrefabs)
            ClientScene.UnregisterPrefab(s);
    }
}

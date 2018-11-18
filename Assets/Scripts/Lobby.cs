using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Lobby : NetworkBehaviour
{

    void Start()
    {

    }
    
    void Update()
    {
        // TODO: check host
        if (Input.GetKeyDown(KeyCode.Space) && Persist.net.IsClientConnected())
        {
            Persist.goodScores = new SyncListInt();
            Persist.evilScores = new SyncListInt();
            Persist.net.ServerChangeScene("LoadingNext");
        }
    }
}

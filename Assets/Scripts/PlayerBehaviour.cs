using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBehaviour : NetworkBehaviour
{
    [SyncVar]
    public int role = 0;

    bool levelDone = false;

    public void LevelDone()
    {
        if (!levelDone)
        {
            levelDone = true;
            CmdLevelDone();
        }
    }

    [Command]
    void CmdLevelDone()
    {
        Persist.net.ServerLevelDone();
    }
}

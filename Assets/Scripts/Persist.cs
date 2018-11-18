using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Persist : NetworkBehaviour
{

    void Start()
    {
        _net = (NetworkController)gameObject.GetComponent(typeof(NetworkController));
        _sl = (SceneList)gameObject.GetComponent(typeof(SceneList));
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    SyncListInt _goodScores;
    SyncListInt _evilScores;

    NetworkController _net;
    SceneList _sl;

    static Persist instance;

    static public SyncListInt goodScores
    {
        get { return instance._goodScores; }
        set { instance._goodScores = value; }
    }

    static public SyncListInt evilScores
    {
        get { return instance._evilScores; }
        set { instance._evilScores = value; }
    }

    static public NetworkController net
    {
        get { return instance._net; }
    }

    static public List<string> levelScenes
    {
        get { return instance._sl.levelScenes; }
    }

    static public Dictionary<string, int> sceneId
    {
        get { return instance._sl.sceneId; }
    }
}

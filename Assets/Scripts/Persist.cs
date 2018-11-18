using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Persist : NetworkBehaviour {

    void Start()
    {
        _net = (NetworkManager)gameObject.GetComponent(typeof(NetworkManager));
        _sl = (SceneList)gameObject.GetComponent(typeof(SceneList));
        instance = this;

        DontDestroyOnLoad(gameObject);
    }
    
    SyncListInt _goodScores;
    SyncListInt _evilScores;

    NetworkManager _net;
    SceneList _sl;

    static Persist instance;

    static public SyncListInt goodScores
    {
        get
        {
            return instance._goodScores;
        }
        set
        {
            instance._goodScores = value;
        }
    }

    static public SyncListInt evilScores
    {
        get
        {
            return instance._evilScores;
        }
        set
        {
            instance._evilScores = value;
        }
    }

    static public NetworkManager net
    {
        get
        {
            return instance._net;
        }
    }

    static public List<string> levelScenes
    {
        get
        {
            return instance._sl.levelScenes;
        }
    }

    static public Dictionary<string, int> sceneId
    {
        get
        {
            return instance._sl.sceneId;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneList : MonoBehaviour {

    public List<string> levelScenes = new List<string>();

    [HideInInspector]
    public Dictionary<string, int> sceneId = new Dictionary<string, int>();

    // Use this for initialization
    void Start () {
        for (int i = 0; i < levelScenes.Count; i++)
            sceneId[levelScenes[i]] = i;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PullBehavior : PlayerBehaviour {

	// Use this for initialization
	void Start () {
        //gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        if (!isLocalPlayer)
            return;
        //OnMouseDown();
	}

    void OnMouseDown()
    {
        if (gameObject.tag == "rightPull")
        {
            Debug.Log("right1");
            GameObject rope = GameObject.Find("rope");
            rope.transform.position = rope.transform.position + new Vector3(1, 0, 0);
            Debug.Log("right2");
        }


        else if (gameObject.tag == "leftPull")
        {
            GameObject rope = GameObject.Find("rope");
            rope.transform.position = rope.transform.position + new Vector3(-1, 0, 0);
            Debug.Log("left");
        }
        gameObject.SetActive(true);
    }

}

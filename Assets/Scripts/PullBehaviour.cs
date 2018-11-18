using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PullBehaviour : PlayerBehaviour
{
    float dir
    {
        get { return role % 2 == 0 ? 1 : -1; }
    }

    void Start()
    {
        transform.position += new Vector3(dir * 7, 0, 0);
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;
    }

    void OnMouseDown()
    {
        GameObject.Find("rope").transform.position += new Vector3(dir, 0, 0);
    }

}

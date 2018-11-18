using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShakeCola : PlayerBehaviour {
    private GameObject colaColor;
    private Vector2 yposition = new Vector2(0, 0);
	// Use this for initialization
	void Start () {
		colaColor = GameObject.Find("ColaColor");
    }
	
	// Update is called once per frame
	void Update () {
        if(!isLocalPlayer){ //只有本機玩家可以操控
            return;
        }

        if(Input.GetMouseButton(0)) //滑鼠左鍵
        {
            CmdShakeCola();
        }
	}

    [Command] //執行shake cola動作（要從client傳到server)
    void CmdShakeCola()
    {
        colaColor.transform.Translate(yposition + new Vector2(0,10));
    }
}

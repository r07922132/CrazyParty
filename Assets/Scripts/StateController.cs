using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {

    public GameObject bow;

	// Use this for initialization
	void Start () {

        ShowInstruct();
		
	}
	
	// Update is called once per frame
	void Update () {


        
		
	}

    void whoWins()
    {
        if (bow.transform.position.x < 0)
        {
            print("left team win!");
            //left member ++ goodscore
        }
        else if (bow.transform.position.x > 0)
        {
            print("right team win!");
            //right member ++ goodscore
        }

    }

    void ShowInstruct()
    {//

    }
}

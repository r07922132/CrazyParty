using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAtWhitchSide : MonoBehaviour {
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D Coll)
    {
        print("is trigger");
        if (Coll.gameObject.name == "1")
        {
            print("Trigger - 1 ");
        }
        else if(Coll.gameObject.name == "2")
        {
            print("Trigger - 2 ");
        }
    }
}

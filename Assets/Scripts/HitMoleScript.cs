using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HitMoleScript : PlayerBehaviour {

    public GameObject Mole;
    public NetworkIdentity[] networkIdentity;


    public Vector2[] holePosition = new Vector2[numOfHole];
    public bool[] holeOccupied = new bool[numOfHole];
    public GameObject[] moleList = new GameObject[numOfHole];
    public Collider2D coll;

    public static int numOfHole;

    // Use this for initialization
    void Start () {
        int i;
        numOfHole = holePosition.Length;

        for (i = 0; i < numOfHole; i++)
        {
            holePosition[i] = GameObject.Find("Hole" + (i+1)).transform.position;
            holeOccupied[i] = false;
        }
	}
   
    // Update is called once per frame
    void Update()
    {
        if (!isServer)
            return;

        if (Random.Range(0, 100) <= 2){
            CmdSpawnMole();
        }

        int i;
        RaycastHit2D hit;

        for (i = 0; i < numOfHole; i++)
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Camera.main.WorldToScreenPoint(holePosition[i])), Vector2.zero);
            //Debug.Log(hit.collider);

            if (hit.collider == null)
            {
                holeOccupied[i] = false;
            }
        }

    }


    [Command]
    void CmdSpawnMole()
    {
        int i;
        int p = Random.Range(0, numOfHole);

        for (i = 0; i < numOfHole; i++)
        {
            if (holeOccupied[i] == false && p % numOfHole == i)
            {
                moleList[i] = Instantiate(Mole, holePosition[i], Quaternion.identity);
                NetworkServer.Spawn(moleList[i]);
                holeOccupied[i] = true;
            }
        }
    }

}

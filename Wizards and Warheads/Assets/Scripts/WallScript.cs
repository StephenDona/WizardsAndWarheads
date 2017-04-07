using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

    public GameObject Brick;

    public int PlayerWall;

    public int wallThick;
    public int wallHeight;
    public float wallHorizontalSpread;
    public float wallVerticalSpread;

    // Use this for initialization
    void Start () {
		BuildPlayerWalls();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void BuildPlayerWalls()
    {
        Vector3 buildLocation = transform.position;

        if(PlayerWall == 2)
        {
            for (int i = 0; i < wallHeight; i++)
            {
                for (int k = 0; k < wallThick; k++)
                {
                    Instantiate(Brick, buildLocation, Quaternion.identity);
                    buildLocation.x = buildLocation.x + wallHorizontalSpread;

                }
                buildLocation.y = buildLocation.y - wallVerticalSpread;
                buildLocation.x = buildLocation.x - wallThick * wallHorizontalSpread;
            }
        }
        else if(PlayerWall == 1)
        {
            for (int i = 0; i < wallHeight; i++)
            {
                for (int k = 0; k < wallThick; k++)
                {
                    Instantiate(Brick, buildLocation, Quaternion.identity);
                    buildLocation.x = buildLocation.x - wallHorizontalSpread;

                }
                buildLocation.y = buildLocation.y - wallVerticalSpread;
                buildLocation.x = buildLocation.x + wallThick * wallHorizontalSpread;
            }
        }
        else
        {
            Debug.Log("WallScript Has no Active Player");
        }

        
    }
}

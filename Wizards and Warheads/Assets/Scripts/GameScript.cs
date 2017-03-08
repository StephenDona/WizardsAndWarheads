using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour
{


    public GameObject Player2WallStart;
    public GameObject Brick;

    public int wallThick;
    public int wallHeight;
    public float wallHorizontalSpread;
    public float wallVerticalSpread;

    // Use this for initialization
    void Start()
    {

        BuildPlayerWalls();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void BuildPlayerWalls()
    {
        Vector3 buildLocation = Player2WallStart.transform.position;

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



}


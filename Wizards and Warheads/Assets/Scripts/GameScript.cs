using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour
{


    public GameObject Player2WallStart;
    public GameObject Player1WallStart;
    public GameObject Brick;

    public int wallThick;
    public int wallHeight;
    public float wallHorizontalSpread;
    public float wallVerticalSpread;

    public static bool Player1Win = false;
    public GameObject Player1EndText;
    public static int player1Missiles;
    public static int player2Missiles;

    // Use this for initialization
    void Start()
    {
        Player1EndText.SetActive(false);
        BuildPlayerWalls();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player1 Missiles: " + player2Missiles + " Player2 Missiles: " + player2Missiles);
    }

    void EndGame()
    {
        if(Player1Win)
        {
            Player1EndText.SetActive(true);
        }
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

        buildLocation = Player1WallStart.transform.position;

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



}


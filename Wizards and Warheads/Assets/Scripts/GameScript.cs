using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour
{


    public static bool Player1Win = false;
    public static bool Player2Win = false;
    public GameObject Player1EndText;
    public static int player1Missiles;
    public static int player2Missiles;

    // Use this for initialization
    void Start()
    {
        Player1EndText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player1 Missiles: " + player1Missiles + " Player2 Missiles: " + player2Missiles);
    }

    void EndGame()
    {
        if(Player1Win)
        {
            Player1EndText.SetActive(true);
        }
    }

}


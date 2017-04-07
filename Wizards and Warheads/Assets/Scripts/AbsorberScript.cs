using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorberScript : MonoBehaviour {

    public int PlayerNum;

    public GameObject Brick;

    GameObject player1;
    GameObject player2;
    Player1Script player1Script;
    Player2Script player2Script;

	// Use this for initialization
	void Start () {
        player1 = GameObject.FindWithTag("Player");
        player2 = GameObject.FindWithTag("Player2");
        player1Script = player1.GetComponent<Player1Script>();
        player2Script = player2.GetComponent<Player2Script>();
	}
	
	// Update is called once per frame
	void Update () {
        TurnOnOffCollider();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Absorb(other.gameObject);
    }

    void Absorb(GameObject i_other)
    {
        if (PlayerNum == 1)
        {
            if (i_other.tag == "Player2")
            {
                player2Script.Player2Respawn();
                Brick.SetActive(true);
            }
        }
        else if (PlayerNum == 2)
        {
            if (i_other.tag == "Player")
            {
                player1Script.Player1Respawn();
                Brick.SetActive(true);
            }
        }
        else
        {
            Debug.Log("AbsorberScript Has no Active Player");
        }
    }
    
    void TurnOnOffCollider()
    {
        if(Brick.activeSelf)
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
        }
        else
        {
            this.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}

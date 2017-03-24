using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour
{

    public float movespeed;
    public int playerMissile;

    public GameObject Brick;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MissileMove();
        SelfDestroy();
    }
    
    void MissileMove()
    {
        if(playerMissile == 1)
        {
            transform.Translate(Vector3.left * Time.deltaTime * movespeed);
        }
        else if(playerMissile == 2)
        {
            transform.Translate(Vector3.right * Time.deltaTime * movespeed);
        }
        else
        {

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DestroyBricks(other.gameObject);
        DestroyHeart(other.gameObject);
        DestroyMissiles(other.gameObject);
    }

    void DestroyBricks(GameObject i_other)
    {
        if (i_other.tag == "Brick")
        {
            Destroy(i_other.gameObject);
            Destroy(gameObject);
            TallyMissiles();
        }
    }

    void DestroyMissiles(GameObject i_other)
    {
        if (i_other.tag == "Missile")
        {
            Destroy(i_other.gameObject);
            Destroy(gameObject);
            GameScript.player2Missiles--;
            GameScript.player1Missiles--;
        }
    }

    void DestroyHeart(GameObject i_other)
    {
        if (i_other.tag == "Player2Heart")
        {
            Destroy(i_other.gameObject);
            Destroy(gameObject);
            TallyMissiles();

            if (playerMissile == 1)
            {
                GameScript.Player1Win = true;
            }
            else if (playerMissile == 2)
            {
                GameScript.Player2Win = true;
            }
            else
            {
                Debug.Log("ERROR: MISSILE HAS NO PLAYER");
            }
            
        }
    }

    void SelfDestroy()
    {
        if(transform.position.x <-35 || transform.position.x > 35)
        {
            Destroy(gameObject);
            TallyMissiles();
        }
    }

    void TallyMissiles()
    {
        if (playerMissile == 1)
        {
            GameScript.player1Missiles--;
        }
        else if (playerMissile == 2)
        {
            GameScript.player2Missiles--;
        }
        else
        {
            Debug.Log("ERROR: MISSILE HAS NO PLAYER");
        }
    }
}


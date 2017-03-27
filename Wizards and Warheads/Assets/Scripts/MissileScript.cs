using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissileScript : MonoBehaviour
{

    public float movespeed;
    public int playerMissile;
    public float launch;

    Rigidbody2D rb;

    public bool MarkedForDetonation;

    public GameObject Brick;
    public GameObject Shockwave;

    List<Rigidbody2D> MissileRiders;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MissileMove();
        SelfDestroy();
        //if(MarkedForDetonation)
        //{
        //    Detonate();
        //}
    }
    
    void MissileMove()
    {
        if(playerMissile == 1)
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
        }
        else if(playerMissile == 2)
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
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
        //AddRider(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //RemoveRider(other.gameObject);
    }

    //void Detonate()
    //{
    //    Destroy(this);
    //    TallyMissiles();
    //    for(int i=0; i<MissileRiders.Count; i++)
    //    {
    //        MissileRiders[i].velocity = new Vector2(rb.velocity.x, launch);
    //    }
    //}

    void DestroyBricks(GameObject i_other)
    {
        if (i_other.tag == "Brick")
        {
            Instantiate(Shockwave, transform.position, Quaternion.identity);
            Destroy(i_other.gameObject);
            Destroy(gameObject);
            TallyMissiles();
        }
    }

    void DestroyMissiles(GameObject i_other)
    {
        if (i_other.tag == "Missile")
        {
            Instantiate(Shockwave, (transform.position+i_other.transform.position)/2, Quaternion.identity);
            Destroy(i_other.gameObject);
            Destroy(gameObject);
            TallyMissiles();
        }
    }

    void DestroyHeart(GameObject i_other)
    {
        if (i_other.tag == "Player2Heart" || i_other.tag == "Player1Heart")
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

    public void TallyMissiles()
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

    //void AddRider(GameObject Rider)
    //{
    //    if (Rider.tag == "Player")
    //    {
    //        Rigidbody2D AddedRider = Rider.GetComponent<Rigidbody2D>();
    //        MissileRiders.Add(AddedRider);
    //    }
            
    //}
    //void RemoveRider(GameObject Rider)
    //{
    //    if (Rider.tag == "Player")
    //    {
    //        MissileRiders.Remove(Rider.GetComponent<Rigidbody2D>());
    //    }
    //}
}


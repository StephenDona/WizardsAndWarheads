using UnityEngine;
using System.Collections;
using System;


public class Player1Script : MonoBehaviour
{

    //Movement
    public float speed;
    public float jump;
    public float launch;
    public int jumpNumMax;
    int jumpNum = 0;

    float moveVelocity;
    bool spawnWarhead;
    Vector3 warheadSpawnPosition;

    Rigidbody2D rb;

    public GameObject missile;
    public GameObject target;
    public GameObject OutOfScreenMarker;
    public GameObject Shockwave;
    public float TargetDistance;
    public int player1MissileMax;

    float screenBottom = -21.0f;
    Vector3 startPos;

    GameObject ground1;
    bool grounded = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        // Use this for initialization
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        PlayerMove();
        StartSpawnWarhead();
        EndSpawnWarhead();
        DetonateBomb();
        Respawn();
        CorrectRotation();
        OutOfScreenRender();

    }

    void PlayerMove()
    {

        if (InputManager.P1MainHorizontal() < -0.5f)
        {
            moveVelocity = -speed;
            rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
        }
        else if (InputManager.P1MainHorizontal() > 0.5f)
        {
            moveVelocity = speed;
            rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
        }
        else
        {

            if (grounded && ground1 != null)
            {
                if(ground1.tag == "Missile")
                {
                    rb.velocity = ground1.GetComponent<Rigidbody2D>().velocity;
                }               
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

        }

        if (InputManager.P1Abutton())
        {
            PlayerJump();
        }




    }

    void PlayerJump()
    {
        if (grounded || jumpNum < jumpNumMax)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            jumpNum++;
        }
    }

    void StartSpawnWarhead()
    {
        float y = InputManager.P1AltVertical();
        float x = InputManager.P1AltHorizontal();
        //Debug.Log(Math.Abs(InputManager.AltHorizontal() + Math.Abs(InputManager.AltVertical())));
        if (Math.Abs(x) + Math.Abs(y) > 0.8)
        {
            //Instantiate(target, transform.position + new Vector3(TargetDistance* InputManager.AltHorizontal(), TargetDistance * InputManager.AltVertical(),0), Quaternion.identity);
            //Debug.Log("x:" + x);
            //Debug.Log("y:" + y);
            float theta = (float)Math.Atan(y / x);
            if (x >= 0)
            {
                target.transform.position = transform.position + new Vector3(TargetDistance * (float)Math.Cos(theta), TargetDistance * (float)Math.Sin(theta), 0);
                warheadSpawnPosition = transform.position + new Vector3(TargetDistance * (float)Math.Cos(theta), TargetDistance * (float)Math.Sin(theta), 0);
            }
            else
            {
                target.transform.position = transform.position + new Vector3(-TargetDistance * (float)Math.Cos(theta), -TargetDistance * (float)Math.Sin(theta), 0);
                warheadSpawnPosition = transform.position + new Vector3(-TargetDistance * (float)Math.Cos(theta), -TargetDistance * (float)Math.Sin(theta), 0);
            }

            target.SetActive(true);
            spawnWarhead = true;
        }
        else
        {
            target.SetActive(false);
        }
    }

    void EndSpawnWarhead()
    {
        float y = InputManager.P1AltVertical();
        float x = InputManager.P1AltHorizontal();
        //Debug.Log(Math.Abs(InputManager.AltHorizontal() + Math.Abs(InputManager.AltVertical())));
        if (Math.Abs(x) + Math.Abs(y) < 0.8 && spawnWarhead)
        {
            if (GameScript.player1Missiles < player1MissileMax)
            {
                if (warheadSpawnPosition.x > 35 || warheadSpawnPosition.x < -35 || warheadSpawnPosition.y > 21 || warheadSpawnPosition.y < -18)
                {

                }
                else
                {
                    Instantiate(missile, warheadSpawnPosition, Quaternion.identity);
                    GameScript.player1Missiles++;
                }

            }

            spawnWarhead = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ground1 = other.gameObject;
        grounded = true;
        jumpNum = 0;
    }

    void OnTriggerExit2D()
    {
        grounded = false;
    }


    void DetonateBomb()
    {
        if (InputManager.P1Bbutton())
        {
            if (grounded && ground1.tag == "Missile")
            {
                ground1.GetComponent<MissileScript>().TallyMissiles();
                Instantiate(Shockwave, ground1.transform.position, Quaternion.identity);
                Destroy(ground1);

                ground1 = null;
            }

        }
    }

    void Respawn()
    {
        if (transform.position.y < screenBottom)
        {
            transform.position = startPos;
        }

    }

    void CorrectRotation()
    {
        if (transform.rotation.z != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.time * 100);
        }
    }

    void OutOfScreenRender()
    {
        if (transform.position.y > 23)
        {
            OutOfScreenMarker.SetActive(true);
            OutOfScreenMarker.transform.position = new Vector3(transform.position.x, 20.0f, 23.65f);
        }
        else
        {
            OutOfScreenMarker.SetActive(false);
        }

    }
}


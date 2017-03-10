using UnityEngine;
using System.Collections;
using System;


public class Player1Script : MonoBehaviour {

    //Movement
    public float speed;
    public float jump;
    public float launch;

    float moveVelocity;
    bool spawnWarhead;
    Vector3 warheadSpawnPosition;

    Rigidbody2D rb;

    public GameObject missile;
    public GameObject target;
    public float TargetDistance;

    float screenBottom = -21.0f;
    Vector3 startPos;

    GameObject ground;
    bool grounded = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        // Use this for initialization
    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        PlayerMove();
        StartSpawnWarhead();
        EndSpawnWarhead();
        DetonateBomb();
        Respawn();

    }

    void PlayerMove()
    {

        if (InputManager.MainHorizontal() < -0.5f)
        {
            moveVelocity = -speed;
            rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
        }
        else if (InputManager.MainHorizontal() > 0.5f)
        {
            moveVelocity = speed;
            rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if(InputManager.Abutton())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }

    void StartSpawnWarhead()
    {
        float y = InputManager.AltVertical();
        float x = InputManager.AltHorizontal();
        //Debug.Log(Math.Abs(InputManager.AltHorizontal() + Math.Abs(InputManager.AltVertical())));
        if(Math.Abs(x) + Math.Abs(y) > 0.8 )
        {
            //Instantiate(target, transform.position + new Vector3(TargetDistance* InputManager.AltHorizontal(), TargetDistance * InputManager.AltVertical(),0), Quaternion.identity);
            //Debug.Log("x:" + x);
            //Debug.Log("y:" + y);
            float theta = (float)Math.Atan(y/x);
            if(x >= 0)
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
        float y = InputManager.AltVertical();
        float x = InputManager.AltHorizontal();
        //Debug.Log(Math.Abs(InputManager.AltHorizontal() + Math.Abs(InputManager.AltVertical())));
        if (Math.Abs(x) + Math.Abs(y) < 0.8 && spawnWarhead)
        {
            Instantiate(missile, warheadSpawnPosition, Quaternion.identity);
            spawnWarhead = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ground = other.gameObject;
        grounded = true;
    }

    void OnTriggerExit2D()
    {
        grounded = false;
    }


    void DetonateBomb()
    {
        if (InputManager.Bbutton())
        {
            if(grounded && ground.tag == "Missile")
            {
                Destroy(ground);
                ground = null;
                rb.velocity = new Vector2(rb.velocity.x, launch);
            }
            
        }
    }

    void Respawn()
    {
        if(transform.position.y < screenBottom)
        {
            transform.position = startPos;
        }

    }
}

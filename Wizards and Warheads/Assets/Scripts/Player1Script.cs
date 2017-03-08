using UnityEngine;
using System.Collections;
using System;


public class Player1Script : MonoBehaviour {

    //Movement
    public float speed;
    public float jump;

    float moveVelocity;

    Rigidbody2D rb;

    public GameObject missile;
    public GameObject target;
    public float TargetDistance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // Use this for initialization
    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        PlayerMove();
        StartSpawnWarhead();
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
        float x = Math.Abs(InputManager.AltVertical());
        float y = Math.Abs(InputManager.AltHorizontal());
        //Debug.Log(Math.Abs(InputManager.AltHorizontal() + Math.Abs(InputManager.AltVertical())));
        if(x + y > 0.8 )
        {
            //Instantiate(target, transform.position + new Vector3(TargetDistance* InputManager.AltHorizontal(), TargetDistance * InputManager.AltVertical(),0), Quaternion.identity);
            float total = x + y;
            x = x / total;
            y = y / total;
            target.transform.position = transform.position + new Vector3(TargetDistance * Math.Sign(InputManager.AltHorizontal())*x, TargetDistance * Math.Sign(InputManager.AltVertical()) * -y, 0);
            target.SetActive(true);
        }
        else
        {
            target.SetActive(false);
        }
    }
}

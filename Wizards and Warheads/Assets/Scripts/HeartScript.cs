using UnityEngine;
using System.Collections;

public class HeartScript : MonoBehaviour {

    public float upAndDownMovement;
    public bool up;
    public float moveSpeed;

    Vector3 startPos;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        MoveUpAndDown();

    }

    void MoveUpAndDown()
    {
        if(up)
        {
            transform.Translate(Vector3.up * Time.deltaTime*moveSpeed);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime*moveSpeed);
        }   

        if(transform.position.y > startPos.y + upAndDownMovement)
        {
            up = false;
        }

        if (transform.position.y < startPos.y - upAndDownMovement)
        {
            up = true;
        }
    }
}

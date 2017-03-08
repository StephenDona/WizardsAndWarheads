using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour {

    float movespeed = 3;

    public GameObject Brick;


    Rigidbody2D BrickCollider;

	// Use this for initialization
	void Start () {
        BrickCollider = Brick.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * Time.deltaTime*movespeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other == BrickCollider)
        {
            Destroy(other.transform.parent.gameObject);
            Destroy(this);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour {

    public float expandSpeed;
    public float launchSpeed;
    public float destroyTime;
    float Timer;
    CircleCollider2D collider;
    
	// Use this for initialization
	void Start () {
        Timer = Time.timeSinceLevelLoad;
        collider = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Expand();

        if(Time.timeSinceLevelLoad > Timer + destroyTime)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    void Expand()
    {
        //collider.radius = collider.radius + expandSpeed;
        transform.localScale += new Vector3(expandSpeed, expandSpeed, expandSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"|| other.tag == "Player2")
        {
            Vector3 pushVector = other.gameObject.transform.position - transform.position;
            Vector3 launchVector = (launchSpeed * pushVector.normalized) / collider.radius;
            other.GetComponent<Rigidbody2D>().velocity = launchVector;
        }

        if (other.tag == "Missile")
        {
            other.GetComponent<MissileScript>().DestroyMissiles(other.gameObject);
        }
    }
}

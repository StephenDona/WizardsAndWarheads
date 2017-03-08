using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour {

    float movespeed = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * Time.deltaTime*movespeed);
    }
}

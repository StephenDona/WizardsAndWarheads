using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour
{

    float movespeed = 3;

    public GameObject Brick;

    public GameObject GameScriptObj;

    GameScript GameScript;

    // Use this for initialization
    void Start()
    {
        GameScript = GameScriptObj.GetComponent<GameScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * movespeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DestroyBricks(other.gameObject);
    }

    void DestroyBricks(GameObject i_other)
    {
        if (i_other.tag == "Brick")
        {
            Destroy(i_other.gameObject);
            Destroy(gameObject);
        }
    }

    void DestroyHeart(GameObject i_other)
    {
        if (i_other.tag == "Player2Heart")
        {
            Destroy(i_other.gameObject);
            GameScript.Player1Win = true;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L4KeyDolphin : MonoBehaviour
{
    public int IsDolphinAlive;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("SeaEnemy"))
        {
            IsDolphinAlive = 1;
            //Debug.Log("There is dolphin:" + IsDolphinAlive);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (!GameObject.FindWithTag("SeaEnemy"))
        {
            IsDolphinAlive = 0;
            //Debug.Log("There is no dolphin:" + IsDolphinAlive);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}

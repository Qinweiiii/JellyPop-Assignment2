using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L2GameManager : MonoBehaviour
{
    private Animator anim;
    private bool p1reach;
    private bool p2reach;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (L2KeyCollector.keys == 3)
        {
            if (collision.gameObject.tag == "Player1")
            {
                p1reach = true;
            }
            if (collision.gameObject.tag == "Player2")
            {
                p2reach = true;
            }

            if (p1reach) 
            {
                if (p2reach)
                {
                    CompleteLevel();
                }
            }
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        L2HealthManager1.health = 5;
        L2HealthManager2.health = 5;
        L2KeyCollector.keys = 0;
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

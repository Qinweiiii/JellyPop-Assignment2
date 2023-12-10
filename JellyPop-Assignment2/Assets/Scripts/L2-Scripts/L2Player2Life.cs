using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L2Player2Life : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    private Animator anim;
      public float time;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            L2HealthManager2.health--;
            if (L2HealthManager2.health <= 0)
            {
                // gameObject.SetActive(false);
                Die();
            }
            else
            {
                anim.SetTrigger("hurt");
                Debug.Log("Player1 is hurt.");
                //StartCoroutine(waitToIdle());
            }

            if (L2HealthManager2.health <= 0)
            {
                // gameObject.SetActive(false);
                Die();
            }
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Die();
            Debug.Log("Player is die");
        }
    }

    IEnumerator waitToIdle()
    {
        yield return new WaitForSeconds(time);

        anim.SetBool("idle", true);
    }


    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("dead");
    }
}

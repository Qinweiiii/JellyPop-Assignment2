using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class L3Player2Life : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            L3HealthManager2.health--;
            if (L3HealthManager2.health <= 0)
            {
                Die();
            }
            else
            {
                //StartCoroutine(GetHurt());
                GetHurt();
            }
        }

        if (collision.gameObject.CompareTag("Magma"))
        {
            L3HealthManager2.health -= 5;
            Die();
        }
    }

    public void EnemyDamage()
    {
        L3HealthManager2.health--;
        if (L3HealthManager2.health <= 0)
        {
            Die();
            StartCoroutine(Disapear());
        }
        else
        {
            GetHurt();
        }
    }

    private void GetHurt()
    {
        anim.SetTrigger("hurt");
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    IEnumerator Disapear()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}

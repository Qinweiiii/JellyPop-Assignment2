using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class L3DragonController : MonoBehaviour
{
    public GameObject dragon;

    public float moveSpeed = 0;

    private Rigidbody2D rb;

    private Animator anim;

    public GameObject fireball;
    public Transform AttackPoint;
    public float attackTimer = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (L3HealthManager1.health > 0 && L3HealthManager2.health > 0)
        {
            if (attackTimer <= 0f)
            {
                attackTimer = 10f;
            }

            if (attackTimer > 0f) 
            {
                attackTimer -= Time.deltaTime;
                if (attackTimer <= 0f)
                {
                    Attack();
                }
            }
        }
    }

    public void PlayerDamage()
    {
        L3DragonHealthManager.health--;
        if (L3DragonHealthManager.health <= 0)
        {
            Die();
            StartCoroutine(Disapear());
        }
        else
        {
            GetHurt();
        }
    }

    void Attack()
    {
        Instantiate(fireball, AttackPoint.position, AttackPoint.rotation);

        anim.SetTrigger("attack");

        attackTimer = 0f;
    }

    private void GetHurt()
    {
        anim.SetTrigger("hurt");
    }

    private void Die()
    {
        anim.SetTrigger("death");
    }

    IEnumerator Disapear()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
       

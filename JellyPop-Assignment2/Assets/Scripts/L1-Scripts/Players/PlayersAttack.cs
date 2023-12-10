using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersAttack : MonoBehaviour
{
    public int damage;
    public float time;

    private Animator anim;
    private PolygonCollider2D coll2D;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coll2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {

        if (Input.GetKey("f"))
        {
            coll2D.enabled = true;
            anim.SetTrigger("attack");
            StartCoroutine(disableHitBox());
        }
        /*else if (Input.GetKeyUp("f"))
        {
            coll2D.enabled = false;
            anim.SetBool("idle", true);
            StartCoroutine(disableHitBox());
        }*/
    }

    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        coll2D.enabled = false;
        anim.SetBool("idle", true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            other.GetComponent<Monster>().TakeDamage(damage);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2AttackPoint1 : MonoBehaviour
{
    public int damage;
    public float time;

    private Animator anim;
    private PolygonCollider2D coll2D;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player1").GetComponent<Animator>();
        coll2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetKey(KeyCode.F))
        {
            coll2D.enabled = true;
            anim.SetTrigger("Attack");
            Debug.Log("The attack is triggered");
            StartCoroutine(disableHitBox());
        }
        // else if (Input.GetKeyUp(KeyCode.F))
        // {
        //     coll2D.enabled = false;
        //     anim.SetBool("idel", true);
        //     StartCoroutine(disableHitBox());
        // }
    }

    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        coll2D.enabled = false;
        anim.SetBool("idel", true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            Debug.Log("The monster is hurt");
            other.GetComponent<L2Monster>().TakeDamage(damage);
        }
    }
    
}
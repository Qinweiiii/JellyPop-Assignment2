using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2 : MonoBehaviour
{
    public int damage;
    public float time;

    private Animator anim;
    private PolygonCollider2D coll2D;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player2").GetComponent<Animator>();
        coll2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetKey(KeyCode.Keypad0))
        {
            coll2D.enabled = true;
            anim.SetTrigger("attack");
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
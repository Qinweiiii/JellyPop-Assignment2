using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L4Musketeer_Attack2: MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            coll2D.enabled = true;
            anim.SetTrigger("M_Attack2");
            StartCoroutine(disableHitBox());
        }
        else if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            coll2D.enabled = false;
            anim.SetBool("M_Idle", true);
            StartCoroutine(disableHitBox());
        }
    }

    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        coll2D.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SeaEnemy"))
        {
            other.GetComponent<L4Dolphin1>().TakeDamage(damage);
        }
        else if (other.gameObject.CompareTag("Octopus"))
        {
            other.GetComponent<L4Octopus>().TakeDamage(damage);
            Debug.Log("Hurt");
        }
    }
}

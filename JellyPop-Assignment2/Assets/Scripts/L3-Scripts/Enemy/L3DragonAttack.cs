using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3DragonAttack : MonoBehaviour
{
    public float attackSpeed;

    private Rigidbody2D rb;

    public L3Player1Life p1;
    public L3Player2Life p2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(attackSpeed * transform.localScale.x, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            p1.EnemyDamage();
        }
        if (collision.gameObject.tag == "Player2")
        {
            p2.EnemyDamage();
        }

    }
}

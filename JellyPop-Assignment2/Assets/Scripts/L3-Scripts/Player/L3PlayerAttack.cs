using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3PlayerAttack : MonoBehaviour
{
    public float attackSpeed = 5;

    private Rigidbody2D rb;

    public L3DragonController dragon_life;

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
        if (collision.gameObject.tag == "Enemy")
        {
            dragon_life.PlayerDamage();
            gameObject.SetActive(false);
        }
    }
}

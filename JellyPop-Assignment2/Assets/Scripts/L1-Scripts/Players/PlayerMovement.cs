using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    //public KeyCode attack;

    private Rigidbody2D rb;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGround;

    private Animator anim;

    public GameObject Attack;
    public Transform AttackPoint;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        isGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        if(Input.GetKey(left))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(jump) && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // if (Input.GetKeyDown(attack))
        // {
        //     GameObject attackClone = (GameObject)Instantiate(Attack, AttackPoint.position, AttackPoint.rotation);
        //     attackClone.transform.localScale = transform.localScale;
            
        //     anim.SetTrigger("attack");
        // }

        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("ground", isGround);

    }
}
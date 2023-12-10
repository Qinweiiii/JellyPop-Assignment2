using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L4PlayerControl_Musketeer : MonoBehaviour
{
    public Rigidbody2D playerRigid_M; // Declaration
    public float x_speed, y_speed;
    public float m_speed = 5f;
    public Vector2 movement;
    public Vector2 targetPos;
    private Animator mAnim;

    public int damage;

    public L4CameraShake cmr_shake;
    public float shaking_time;

    // Start is called before the first frame update
    void Start()
    {
        if (playerRigid_M == null)
        {
            playerRigid_M = this.gameObject.GetComponent<Rigidbody2D>(); // Instancialization
        }
        mAnim = GetComponent<Animator>();
    }

    void Update()
    {
        M_Swim();
    }

    // Update is called once per frame
    void M_Swim()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x_speed = -4;
            transform.localRotation = Quaternion.Euler(0, 180, -15);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            x_speed = 4;
            transform.localRotation = Quaternion.Euler(0, 0, -15);
        }
        else if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            x_speed = 0;
            //mAnim.SetBool("M_Idle", true);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            y_speed = 4;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            y_speed = -4;
        }
        else if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            y_speed = 0;
        }
        movement = new Vector2(x_speed, y_speed);
        targetPos = playerRigid_M.position + movement * Time.deltaTime * m_speed;

        playerRigid_M.MovePosition(targetPos);

        bool playerHasXAxisSpeed = Mathf.Abs(movement.x) > Mathf.Epsilon;
        mAnim.SetBool("M_Swim", playerHasXAxisSpeed);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            cmr_shake.IsShake = 1;
            StartCoroutine(CompleteShaking());
        }
    }

    IEnumerator CompleteShaking()
    {
        yield return new WaitForSeconds(shaking_time);
        cmr_shake.IsShake = 0;
    }

}

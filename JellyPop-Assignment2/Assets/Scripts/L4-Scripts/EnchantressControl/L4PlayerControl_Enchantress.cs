using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L4PlayerControl_Enchantress : MonoBehaviour
{
    public Rigidbody2D playerRigid_E; // Declaration
    public float x_speed, y_speed;
    public float m_speed = 5f;
    public Vector2 movement;
    public Vector2 targetPos;
    private Animator eAnim;

    public int damage;

    public L4CameraShake cmr_shake;
    public float shaking_time;

    // Start is called before the first frame update
    void Start()
    {
        if (playerRigid_E == null)
        {
            playerRigid_E = this.gameObject.GetComponent<Rigidbody2D>(); // Instancialization
        }
        eAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D_Bubble(Collider2D collision)
    {
        if (collision.tag == "Bubble")
        {
            //Invoke("Restart", 2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        E_Swim();

    }

    // Update is called once per frame
    void E_Swim()
    {
        if (Input.GetKey(KeyCode.A))
        {
            x_speed = -4;
            transform.localRotation = Quaternion.Euler(0, 180, -15);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            x_speed = 4;
            transform.localRotation = Quaternion.Euler(0, 0, -15);
        }
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            x_speed = 0;
            //eAnim.SetBool("E_Idle", true);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            y_speed = 4;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            y_speed = -4;
        }
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            y_speed = 0;
        }
        movement = new Vector2(x_speed, y_speed);
        targetPos = playerRigid_E.position + movement * Time.deltaTime * m_speed;

        playerRigid_E.MovePosition(targetPos);

        bool playerHasXAxisSpeed = Mathf.Abs(movement.x) > Mathf.Epsilon;
        eAnim.SetBool("E_Swim", playerHasXAxisSpeed);
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

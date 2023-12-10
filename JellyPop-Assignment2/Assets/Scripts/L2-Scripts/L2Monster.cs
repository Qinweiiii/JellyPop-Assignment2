using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2Monster : MonoBehaviour
{
    public int Health;
    private Animator anim;
    public float time;

    public float speed;
    public float startWaitTime;
    private float waitTime;

    //public KeyDolphin keyDolphin;
    //public GameObject keydolphin;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Monster").GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Death();

    }

    void Death()
    {
        if (Health <= 0)
        {
            StartCoroutine(destroyMonster());
        }

    }

    IEnumerator destroyMonster()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }


    public void TakeDamage(int damage)
    {
        Debug.Log("The monster is hurt");
        Health -= damage;
    }

}
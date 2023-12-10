using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int health;
    //public int damage;
    private Animator anim;
    public float time;

    // Start is called before the first frame update
    public void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Monster").GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
       if(health <= 0)
       {
        Destroy(gameObject);
       }
    }

    IEnumerator destroyMonster()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

}

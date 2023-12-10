using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L4Octopus : MonoBehaviour
{
    public int Health;
    private Animator anim;
    public float time;

    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Octopus").GetComponent<Animator>();
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        Death();

        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }

    void Death()
    {
        if (Health <= 0)
        {
            StartCoroutine(destroyDolphin());
        }

    }

    IEnumerator destroyDolphin()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }


    public void TakeDamage(int damage)
    {
        Health -= damage;
    }

}

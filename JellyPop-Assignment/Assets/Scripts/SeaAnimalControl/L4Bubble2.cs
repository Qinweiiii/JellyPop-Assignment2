using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class L4Bubble2 : MonoBehaviour
{
    public float speed;
    public float radius;

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            float distance = (transform.position - playerTransform.position).sqrMagnitude;

            if (distance < radius)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position,
                    speed * Time.deltaTime);
            }
        }
    }
}

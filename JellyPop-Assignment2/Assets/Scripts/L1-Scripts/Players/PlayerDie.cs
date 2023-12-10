using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{

    /*private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.CompareTag("DieRegion")) // Check if the collider has the player tag
        {
            Debug.Log("Player Retreat dieregion");
            Die(); // Call the Die method
        }
    }*/

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("DieRegion"))
        {
            Debug.Log("Player Retreat dieregion");
            Die(); // Call the Die method
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

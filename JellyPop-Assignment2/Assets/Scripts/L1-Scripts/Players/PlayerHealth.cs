using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour 
{
 
   public int health =5;
   public GameManager gameManager;

   void Start()
   {
        
   }

   public void TakeDamage(int damage)
   {
        health -= damage;
        if(health <= 0)
        {
            Die();
            
        }
   }

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
        // Notify the GameManager that a player has died
        gameManager.PlayerDied();
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

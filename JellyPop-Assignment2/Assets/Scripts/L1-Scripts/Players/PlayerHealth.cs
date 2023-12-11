using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{
 
   public int health =5;

   public Image[] hearts;
   public Sprite fullHeart;
   public Sprite emptyHeart;


   void Start()
   {
        
   }

   void Update()
   {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
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
       
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

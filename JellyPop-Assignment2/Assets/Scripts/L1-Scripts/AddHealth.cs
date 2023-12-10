using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddHealth : PlayerHealth
{
    public PlayerHealth playerHealth;
    //[SerializeField] private Text keysText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Health"))
        {
            Destroy(collision.gameObject);
            playerHealth.health++;
            //keysText.text = "Keys: " + keys;
        }
    }
}

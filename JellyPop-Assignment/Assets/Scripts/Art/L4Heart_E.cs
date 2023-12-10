using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class L4Heart_E: MonoBehaviour
{
    private int heart_E = 5;

    [SerializeField] private Text heartE_Text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            heart_E--;
            heartE_Text.text = "Enchantress:" + heart_E;
            if (heart_E <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}

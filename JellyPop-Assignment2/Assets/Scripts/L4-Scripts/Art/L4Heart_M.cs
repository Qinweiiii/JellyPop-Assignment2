using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class L4Heart_M : MonoBehaviour
{
    private int heart_M = 5;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < heart_M; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            heart_M--;
            Debug.Log("Heart_E: " + heart_M);
            //heartM_Text.text = "Musketeer:" + heart_M;
            if (heart_M <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}

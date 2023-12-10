using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L3GameManager : MonoBehaviour
{
    private Animator anim;
    private bool p1reach;
    private bool p2reach;

    public GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (L3ItemCollector.keys == 3)
        {
            anim.SetTrigger("open");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (L3ItemCollector.keys == 3)
        {
            if (collision.gameObject.tag == "Player1")
            {
                p1reach = true;
            }
            if (collision.gameObject.tag == "Player2")
            {
                p2reach = true;
            }

            if (p1reach) 
            {
                if (p2reach)
                {
                    CompleteLevel();
                }
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void GoToHome()
    {
        SceneManager.LoadScene("Home");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        L3HealthManager1.health = 5;
        L3HealthManager2.health = 5;
        L3ItemCollector.keys = 0;
        L3DragonHealthManager.health = 12;
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

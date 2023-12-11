using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L3GameManager : MonoBehaviour
{
    private Animator anim;
    private int en;
    private int mu;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            en = 1;
            Debug.Log("Enchantress is arriving.");
            Debug.Log("KeyNo: " + L3ItemCollector.keys);
        }
        else if (other.gameObject.CompareTag("Player2"))
        {
            mu = 1;
            Debug.Log("Musketeer is arriving.");
            Debug.Log("KeyNo: " + L3ItemCollector.keys);
        }
        else if (L3ItemCollector.keys == 3)
        {
            Debug.Log("Key is enough.");
        }

        if (en == 1 && mu == 1 && L3ItemCollector.keys == 3)
        {
            CompleteLevel3();
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
        SceneManager.LoadScene("StartGame");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        L3HealthManager1.health = 5;
        L3HealthManager2.health = 5;
        L3ItemCollector.keys = 0;
        L3DragonHealthManager.health = 12;
    }

    private void CompleteLevel3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

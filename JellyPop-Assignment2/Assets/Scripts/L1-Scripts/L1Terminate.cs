using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L1Terminate : MonoBehaviour
{
    public GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}

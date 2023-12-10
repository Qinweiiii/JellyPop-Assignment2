using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L2LevelFinish : MonoBehaviour
{
    private int en;
    private int mu;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            en = 1;
            Debug.Log("Enchantress is arriving.");
            //Debug.Log("KeyNo: " + keyNo);
        }
        else if (other.gameObject.CompareTag("Player2"))
        {
            mu = 1;
            Debug.Log("Musketeer is arriving.");
            //Debug.Log("KeyNo: " + keyNo);
        }
        if (en==1 && mu==1 && L2KeyCollector.keys==3)
        {
            Debug.Log("Door Open.");
            finishLevel2();
        }
    }

    private void finishLevel2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
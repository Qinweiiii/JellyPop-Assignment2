using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L1LevelFinish : MonoBehaviour
{
    private int en;
    private int mu;
    public int keys;
    //public KeyCollect KC;
    // Start is called before the first frame update
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            en = 1;
            Debug.Log("Enchantress is arriving.");
            Debug.Log("KeyNo: " + keys);
        }
        else if (other.gameObject.CompareTag("Player2"))
        {
            mu = 1;
            Debug.Log("Musketeer is arriving.");
            Debug.Log("KeyNo: " + keys);
        }
        else if (keys == 3)
        {
            //ke = 1;
            Debug.Log("Key is enough.");
        }
        if (en==1 && mu==1 && keys==3)
        {
            finishLevel1();
        }
    }

    private void finishLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L4LevelFinish : MonoBehaviour
{
    private int en;
    private int mu;
    public int keyNo;
    public L4KeyCollection KC;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            en = 1;
            Debug.Log("Enchantress is arriving.");
            Debug.Log("KeyNo: " + keyNo);
        }
        else if (other.gameObject.CompareTag("Player2"))
        {
            mu = 1;
            Debug.Log("Musketeer is arriving.");
            Debug.Log("KeyNo: " + keyNo);
        }
        else if (keyNo == 3)
        {
            //ke = 1;
            Debug.Log("Key is enough.");
        }
        if (en==1 && mu==1 && keyNo==3)
        {
            finishLevel4();
        }
    }

    private void finishLevel4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCollect : MonoBehaviour
{
    
    public L1LevelFinish L1;
    //public static int keys = 0;
    [SerializeField] public Text keyCollection_text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Keys"))
        {
            L1.keys++;
            Debug.Log("Key:" +L1.keys);
            keyCollection_text.text = "Key:" + L1.keys;
            Destroy(collision.gameObject);
        }
    }
   
}

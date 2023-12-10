using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L4KeyCollection : MonoBehaviour
{
    public L4LevelFinish LF;

    [SerializeField] public Text keyCollection_text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            LF.keyNo++;
            Debug.Log("Key: " + LF.keyNo);
            keyCollection_text.text = "Key:" + LF.keyNo;
            Destroy(collision.gameObject);
        }
    }
}

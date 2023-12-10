using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L3ItemCollector : MonoBehaviour
{
    public static int keys = 0;

    [SerializeField] private Text keysText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            keys++;
            keysText.text = "Keys: " + keys;
        }
    }
}

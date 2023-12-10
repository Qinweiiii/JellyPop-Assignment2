using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L3DragonHealthManager : MonoBehaviour
{
    public static int health = 12;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private Animator anim;

    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }
}

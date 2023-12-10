using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDown : MonoBehaviour
{
    private Animator _animator;
   
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    [ContextMenu(itemName:"Down")]
    public void Down()
    {
        _animator.SetTrigger(name:"Down");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowStop : MonoBehaviour
{
    private Animator _animator;
   
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    [ContextMenu(itemName:"Stop")]
    public void Stop()
    {
        _animator.SetTrigger(name:"Stop");
    }
}

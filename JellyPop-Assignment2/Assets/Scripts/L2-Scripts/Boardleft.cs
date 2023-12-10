using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boardleft : MonoBehaviour
{
    private Animator _animator;
   
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    [ContextMenu(itemName:"Left")]
    public void Left()
    {
        _animator.SetTrigger(name:"Left");
    }
}

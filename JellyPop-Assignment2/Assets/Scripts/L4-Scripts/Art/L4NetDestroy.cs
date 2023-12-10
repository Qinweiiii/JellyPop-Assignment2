using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L4NetDestroy : MonoBehaviour
{
    public int IsOctopusAlive;

    // Start is called before the first frame update
    void Start()
    {
        IsOctopusAlive = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Octopus"))
        {
            IsOctopusAlive = 1;
            //Debug.Log("There is Octopus:" + IsOctopusAlive);
        }
        else if (!GameObject.FindWithTag("Octopus"))
        {
            IsOctopusAlive = 0;
            //Debug.Log("There is no Octopus:" + IsOctopusAlive);
            Destroy(gameObject);
        }
    }
}

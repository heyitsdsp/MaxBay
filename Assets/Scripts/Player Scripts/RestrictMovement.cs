using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictMovement : MonoBehaviour
{
    [SerializeField]
    Transform endLeft;
    [SerializeField]
    Transform endRight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WrapMovement();
    }
    void WrapMovement()
    {
        if (transform.position.x < endLeft.position.x)
        {
            transform.position = endLeft.position;
        }
        else if (transform.position.x > endRight.position.x)
        {
            transform.position = endRight.position;
        }
    }
}

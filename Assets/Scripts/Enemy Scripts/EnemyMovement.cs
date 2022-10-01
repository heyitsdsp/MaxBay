using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float velocityY;
    public bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            Movement(); 
        }
    }
    void Movement()
    {
        transform.Translate(Vector3.down * velocityY * Time.deltaTime);
    }
    
}

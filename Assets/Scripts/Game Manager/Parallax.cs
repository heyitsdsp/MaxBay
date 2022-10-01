using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    Vector2 speed;
    Vector2 offset;
    Material material;
    CollisionScript playerCollision;
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        playerCollision = GameObject.FindGameObjectWithTag("Player").GetComponent<CollisionScript>();
    }

    void Update()
    {
        if (playerCollision.isAlive)
        {
            ScrollBackground();
        }
        
    }

    void ScrollBackground()
    {
        offset = speed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}

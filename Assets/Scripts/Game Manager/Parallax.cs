using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    Vector2 speed;
    Vector2 offset;
    Material material;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        ScrollBackground();
    }

    void ScrollBackground()
    {
        offset = speed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}

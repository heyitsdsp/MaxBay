using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource aud;
    [SerializeField]
    AudioClip clipA;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        if(aud != null)
        {
            aud.clip = clipA;
            aud.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

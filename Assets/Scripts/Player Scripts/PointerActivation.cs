using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerActivation : MonoBehaviour
{
    [SerializeField]
    GameObject[] pointers;
    void Start()
    {
        for(int i = 0; i < pointers.Length; i++)
        {
            pointers[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActiavtePointer(int index)
    {
        for(int i = 0; i < pointers.Length; i++)
        {
            pointers[i].SetActive(false);
        }
        pointers[index].SetActive(true);
    }
    public void DeactivateAllPointers()
    {
        for (int i = 0; i < pointers.Length; i++)
        {
            pointers[i].SetActive(false);
        }
    }

}

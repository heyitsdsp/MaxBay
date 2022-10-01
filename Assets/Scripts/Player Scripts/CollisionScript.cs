using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [SerializeField]
    GameObject explosionPrefab;
    UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameObject exploPref = Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
            Destroy(exploPref);
            Destroy(explosionPrefab, 2f);
            uIManager.Damage();
        }
    }
    public void BlinkPlayer()
    {

    }
    
}

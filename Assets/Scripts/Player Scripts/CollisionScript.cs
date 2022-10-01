using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [SerializeField]
    GameObject explosionPrefab;
    UIManager uIManager;
    // MeshRenderer mesh;
    // BoxCollider collider;
    public bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        isAlive = true;
        //collider = GetComponent<BoxCollider>();
      //  mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
           // GameObject exploPref = Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
           // Destroy(exploPref,2f);
           
            uIManager.Damage();
            Destroy(other.gameObject);
        }
    }
    public void BlinkPlayer()
    {
        StartCoroutine(Blinking());
    }
    IEnumerator Blinking()
    {
        uIManager.inVulnerable = true;
        transform.localScale = new Vector3(0f, 0f, 0f);
        yield return new WaitForSeconds(0.3f);
        transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        yield return new WaitForSeconds(0.3f);
        transform.localScale = new Vector3(0f, 0f, 0f);
        yield return new WaitForSeconds(0.3f);
        transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        yield return new WaitForSeconds(0.3f);
        transform.localScale = new Vector3(0f, 0f, 0f);
        yield return new WaitForSeconds(0.3f);
        transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        yield return new WaitForSeconds(0.3f);
        uIManager.inVulnerable = false;



    }
    
}

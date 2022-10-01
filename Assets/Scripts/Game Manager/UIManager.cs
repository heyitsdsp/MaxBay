using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;
    float timeFlow;
    float startTime;
    public bool onRestart;
    [SerializeField]
    int multiplier;
    public int health = 3;
    [SerializeField]
    Image healthImage;
    [SerializeField]
    Sprite[] healthSprite;
    CollisionScript playerCollision;
    public bool inVulnerable = false;
    [SerializeField]
    TextMeshProUGUI deathText;
    // Start is called before the first frame update

    private void Awake()
    {
        startTime = 0;
        healthImage.sprite = healthSprite[2];
        deathText.gameObject.SetActive(false);
    }
    void Start()
    {
        playerCollision = GameObject.FindGameObjectWithTag("Player").GetComponent<CollisionScript>();
    }
    

    // Update is called once per frame
    void Update()
    {
        CheckResetCondition();
        timeFlow=Time.time;
        if (playerCollision.isAlive)
        {
            ScoreValue();
        }
        
        Restart();
       // Debug.Log(Time.time);
    }
    void CheckResetCondition()
    {
        if (onRestart && !playerCollision.isAlive)
        {
            startTime = Time.time;
            onRestart = false;
        }
    }
    void ScoreValue()
    {

        scoreText.text = "SCORE: "+ (int)((timeFlow-startTime)*multiplier);
    }
    public void Damage()
    {
        if (!inVulnerable)
        {
            health--;
            playerCollision.BlinkPlayer();
            if (health < 1)
            {
                DeathMessage();
                playerCollision.isAlive = false;
                Destroy(playerCollision.gameObject,1f);
            }
            else
            {
                healthImage.sprite = healthSprite[health - 1];
            }
            
        }
        

    }
    void DeathMessage()
    {
        StartCoroutine(flashTextCoroutine());
    }
    IEnumerator flashTextCoroutine()
    {
       // while (!playerCollision.isAlive)
        {
            deathText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            deathText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            deathText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            deathText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            deathText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            deathText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            deathText.gameObject.SetActive(true);
        }

    }
    void Restart()
    {
        if (!playerCollision.isAlive)
        {
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                onRestart = true;
                SceneManager.LoadScene(1);
            }
            else if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene(0);
            }
        }
        
    }
}

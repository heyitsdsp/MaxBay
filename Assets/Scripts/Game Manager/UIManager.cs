using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    // Start is called before the first frame update

    private void Awake()
    {
        startTime = 0;
        healthImage.sprite = healthSprite[2];
    }
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        CheckResetCondition();
        timeFlow=Time.time;
        ScoreValue();
       // Debug.Log(Time.time);
    }
    void CheckResetCondition()
    {
        if (onRestart)
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
        health--;
        if (health < 1)
        {
            //player blink
        }
        healthImage.sprite = healthSprite[health - 1];

    }
}

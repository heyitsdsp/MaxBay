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
    // Start is called before the first frame update

    private void Awake()
    {
        startTime = 0;
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
}

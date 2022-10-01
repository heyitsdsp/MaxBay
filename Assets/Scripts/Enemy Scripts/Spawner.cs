using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemyPrefabs;
    [SerializeField]
    float minTime;
    [SerializeField]
    float maxTime;
    [SerializeField]
    Transform[] spawnPos;
    bool spawn=true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            spawn = false;
            StartCoroutine(DelayBetweenSpawns());

        }
    }
    IEnumerator DelayBetweenSpawns()
    {
        float time = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(time);
        int index = Random.Range(0, enemyPrefabs.Length);
        int spawnIndex = Random.Range(0, spawnPos.Length);
        GameObject spawnedEnemy = Instantiate(enemyPrefabs[index], spawnPos[spawnIndex].position, Quaternion.identity);
        spawnedEnemy.SetActive(true);
        spawn = true;
        Destroy(spawnedEnemy, 20f);

    }
    
}

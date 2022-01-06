using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] BaseScript baseScript;

    [SerializeField] float spawnRate = 2f;
    public float timer = 0;


    private float rangeX = 10;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", 2, spawnRate);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            SpawnRandomEnemy();
        }
        timer += Time.deltaTime;

        if (timer >= 2)
        {
            spawnRate -= 0.5f;
            timer = 0;
        }

        Mathf.Clamp(spawnRate,0,10);




    }

    void SpawnRandomEnemy()
    {
        if (!baseScript.hitBase)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-rangeX, rangeX), 7, 0);
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }

    }
}

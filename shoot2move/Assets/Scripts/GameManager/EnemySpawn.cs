using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    public float xBounds = 15f;
    public float yBounds = 15f;

    public int concurrentMaxEnemies = 3;
    public int waveEnemiesRemaining = 5;
    public int maxEnemies = 5;
    public float spawnTimer = 1f;

    public List<GameObject> enemyList;
    public GameObject enemyChaser;
    public GameObject enemyShooter;
    public GameObject enemySpiralShooter;
    public GameObject enemyCharger;
    private Vector2 spawnPosition;
    private bool canSpawn;
    private float lastSpawnTime;

    private bool waveOver;
    public int currentWave;

    public GameObject countdownText;


    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        waveOver = false;
        currentWave = 1;
        lastSpawnTime = Time.time;
        enemyList = new List<GameObject>()
        {
            enemyChaser,
            enemyShooter,
            enemySpiralShooter,
            enemyCharger
        };
    }

    // Update is called once per frame
    void Update()
    {
        WaveControl();
    }

    void WaveControl()
    {
        if (waveOver == false)
        {
            Invoke("Spawner", 4f);
        }
        else if (waveOver == true)
        {
            CancelInvoke();
            Instantiate(countdownText);
            WaveDifficultyUp();
            canSpawn = true;
        }
    }

    void WaveDifficultyUp()
    {
        currentWave += 1;
        if(concurrentMaxEnemies < 10)
        {
            concurrentMaxEnemies += 1;
        }
        maxEnemies += 1;
        waveEnemiesRemaining = maxEnemies;

        for (int i = 0; i < enemyList.Count; i++)
        {
            Debug.Log(enemyList.Count);
            if(i == 0)
            {
                enemyList[i].GetComponent<Enemy1>().chaser.maxSpeed += 0.2f;
            }
            if (i == 1)
            {
                enemyList[i].GetComponent<Enemy2>().shooter.rateOfFire += 0.2f;
            }
            if (i == 2)
            {
                enemyList[i].GetComponent<Enemy3>().spinShooter.rateOfFire += 0.2f;
            }

        }
        waveOver = false;
    }

    void Spawner()
    {
        if (Time.time - lastSpawnTime > spawnTimer)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < concurrentMaxEnemies && canSpawn == true && waveEnemiesRemaining > 0)
            {
                Instantiate(enemyList[Random.Range(0, enemyList.Count)], RandomSpawnPosition(), transform.rotation);
                waveEnemiesRemaining -= 1;
                lastSpawnTime = Time.time;
            }
            else if (GameObject.FindGameObjectsWithTag("Enemy").Length >= concurrentMaxEnemies && canSpawn == true && waveEnemiesRemaining > 0)
            {
                canSpawn = false;
                lastSpawnTime = Time.time;
            }
            else if (GameObject.FindGameObjectsWithTag("Enemy").Length < concurrentMaxEnemies && canSpawn == false && waveEnemiesRemaining > 0)
            {
                canSpawn = true;
            }
            else if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && waveEnemiesRemaining == 0)
            {
                canSpawn = false;
                waveOver = true;
            }
        }
    }

    Vector2 RandomSpawnPosition()
    {
        spawnPosition = new Vector2(Random.Range(-xBounds / 2, xBounds / 2), Random.Range(-yBounds / 2, yBounds / 2));
        return spawnPosition;
    }
}

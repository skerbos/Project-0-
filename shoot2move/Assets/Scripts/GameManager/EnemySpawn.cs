using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float xBounds = 15f;
    public float yBounds = 15f;
    public int maxEnemies = 5;
    public float spawnTimer = 1f;
    public List<GameObject> enemyList;
    public GameObject enemyChaser;
    public GameObject enemyShooter;
    public GameObject enemySpiralShooter;
    private Vector2 spawnPosition;
    private bool canSpawn;
    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        lastSpawnTime = Time.time;
        enemyList = new List<GameObject>()
        {
            enemyChaser,
            enemyShooter,
            enemySpiralShooter
        };
    }

    // Update is called once per frame
    void Update()
    {
        Spawner();
    }

    void Spawner()
    {
        if (Time.time - lastSpawnTime > spawnTimer)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies && canSpawn == true)
            {
                Instantiate(enemyList[Random.Range(0, enemyList.Count)], RandomSpawnPosition(), transform.rotation);
                lastSpawnTime = Time.time;
            }
            else if (GameObject.FindGameObjectsWithTag("Enemy").Length >= 10 && canSpawn == true)
            {
                canSpawn = false;
                lastSpawnTime = Time.time;
            }
        }
    }

    Vector2 RandomSpawnPosition()
    {
        spawnPosition = new Vector2(Random.Range(-xBounds / 2, xBounds / 2), Random.Range(-yBounds / 2, yBounds / 2));
        return spawnPosition;
    }
}

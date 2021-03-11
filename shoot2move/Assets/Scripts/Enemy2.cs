using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private float nextFire;
    private GameObject player;
    private Rigidbody2D rb;
    public GameObject bullet;
    public EnemyClasses.BasicEnemy shooter = new EnemyClasses.BasicEnemy(20f, 2f, 10f, 2f, 5f, 10f, 0);
    // Start is called before the first frame update
    void Start()
    {
        shooter.nextFire = Time.time;
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        shooter.TrackPlayer(gameObject, player);
        shooter.Shoot(gameObject, bullet);
    }
}

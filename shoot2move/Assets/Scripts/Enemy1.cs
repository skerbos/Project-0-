using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public EnemyClasses.BasicEnemy chaser = new EnemyClasses.BasicEnemy(25f, 5f, 10f, 0f, 0f, 0f, 0f);

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        chaser.TrackPlayer(gameObject, player);
    }
    void FixedUpdate()
    {
        chaser.Move(gameObject, rb);
        chaser.LimitMaxSpeed(rb);
    }
}

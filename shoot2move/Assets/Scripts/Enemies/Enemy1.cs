using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private GameObject player;
    private GameObject playerGun;
    private GameObject playerCamera;
    private Rigidbody2D rb;
    public EnemyClasses.BasicEnemy chaser = new EnemyClasses.BasicEnemy(25f, 5f, 10f, 0f, 0f, 0f, 0f);
    public GameObject deathParticles;
    public AudioSource deathSound;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerGun = GameObject.FindGameObjectWithTag("PlayerGun");
        playerCamera = GameObject.FindGameObjectWithTag("CameraHolder");
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            chaser.TakeDamage(playerGun);
            chaser.Death(gameObject, deathParticles, deathSound, playerCamera);
        }

    }
}

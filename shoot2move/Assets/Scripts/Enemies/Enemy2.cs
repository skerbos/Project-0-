using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private float nextFire;
    private GameObject player;
    private GameObject playerGun;
    private GameObject playerCamera;
    public GameObject deathParticles;
    public AudioSource deathSound;
    private Rigidbody2D rb;
    public GameObject bullet;
    public EnemyClasses.BasicEnemy shooter = new EnemyClasses.BasicEnemy(20f, 2f, 10f, 0.5f, 5f, 10f, 0);
    // Start is called before the first frame update
    void Start()
    {
        shooter.nextFire = Time.time;
        player = GameObject.FindGameObjectWithTag("Player");
        playerGun = GameObject.FindGameObjectWithTag("PlayerGun");
        playerCamera = GameObject.FindGameObjectWithTag("CameraHolder");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        shooter.TrackPlayer(gameObject, player);
        shooter.Shoot(gameObject, bullet);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            shooter.TakeDamage(playerGun);
            shooter.Death(gameObject, deathParticles, deathSound, playerCamera);
        }
    }
}

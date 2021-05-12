using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public GameObject enemyBullet;
    public int bulletsPerShot = 5;
    public EnemyClasses.BasicEnemy spinShooter = new EnemyClasses.BasicEnemy(20f, 2f, 10f, 0.5f, 5f, 10f, 0);
    public GameObject deathParticles;
    public AudioSource deathSound;
    private Rigidbody2D rb;
    private GameObject playerGun;
    private GameObject playerCamera;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        playerGun = GameObject.FindGameObjectWithTag("PlayerGun");
        playerCamera = GameObject.FindGameObjectWithTag("CameraHolder");
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        ShootRaidally();
        Spin();
    }

    void ShootRaidally()
    {
        if (Time.time > nextFire)
        {
            for (int i = 1; i <= bulletsPerShot; i++)
            {
                Instantiate(enemyBullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, i*(360f/bulletsPerShot)));
            }
            nextFire = Time.time + 1.5f;
        }
    }

    void Spin()
    {
        rb.angularVelocity = 20f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            spinShooter.TakeDamage(playerGun);
            spinShooter.Death(gameObject, deathParticles, deathSound, playerCamera);
        }

    }
}

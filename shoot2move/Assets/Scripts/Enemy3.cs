using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public GameObject enemyBullet;
    public int bulletsPerShot = 5;
    private Rigidbody2D rb;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
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
            nextFire = Time.time + 0.5f;
        }
    }

    void Spin()
    {
        rb.angularVelocity = 20f;
    }
}

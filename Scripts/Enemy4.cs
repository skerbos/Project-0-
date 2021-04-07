using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    public GameObject player;
    private GameObject playerGun;
    private Rigidbody2D rb;
    public EnemyClasses.BasicEnemy charger = new EnemyClasses.BasicEnemy(25f, 10f, 25f, 0f, 0f, 0f, 0f);
    public float speed;
    public float radius;
    public float chargeSpeed;
    public Vector2 direction;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        direction = direction.normalized;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= radius)
        {
            charger.maxSpeed = chargeSpeed;
            charger.Move(gameObject, rb);
            charger.LimitMaxSpeed(rb);
            
        }
        else if (Vector2.Distance(transform.position, player.transform.position) > radius)
        {
            charger.TrackPlayer(gameObject, player);
            charger.maxSpeed = speed;
            charger.Move(gameObject, rb);
            charger.LimitMaxSpeed(rb);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            charger.TakeDamage(playerGun);
            charger.Death(gameObject);
        }

    }
}
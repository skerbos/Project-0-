using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : MonoBehaviour
{

    private Rigidbody2D rb;
    public float moveForce = 200f;
    public float maxSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Move();
        LimitMaxSpeed();
    }

    void Move()
    {
        rb.AddForce(transform.up * moveForce, ForceMode2D.Impulse);
    }

    void LimitMaxSpeed()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
        }
        Destroy(gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private GameObject playerGun;
    public float moveForce = 200f;
    private float maxSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        playerGun = GameObject.FindWithTag("PlayerGun");
        maxSpeed = playerGun.GetComponent<GunControl>().currentWeapon.bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        LimitMaxSpeed();
    }

    void Move()
    {
        rb.AddForce(-transform.up * moveForce, ForceMode2D.Impulse);
    }

    void LimitMaxSpeed()
    {
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Yes");
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity.normalized * 0;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-transform.up * playerGun.GetComponent<GunControl>().currentWeapon.bulletForce);
        }
        Destroy(gameObject);
    }
}

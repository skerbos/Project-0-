using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBulletMove : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private GameObject playerGun;
    public Text damageText;
    public float moveForce = 200f;
    private float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        playerGun = GameObject.FindWithTag("PlayerGun");
        maxSpeed = playerGun.GetComponent<GunControl>().currentWeapon.bulletSpeed;

        Destroy(gameObject, 0.4f);
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
        rb.AddForce(transform.right * moveForce, ForceMode2D.Impulse);
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
            Instantiate(damageText, Camera.main.WorldToScreenPoint(collision.transform.position) + new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), 0), Quaternion.Euler(0,0,0));
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity.normalized * 0;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * playerGun.GetComponent<GunControl>().currentWeapon.bulletForce);
        }
        Destroy(gameObject);
    }
}

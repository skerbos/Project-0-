using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    
    private Rigidbody rb;
    public float moveForce = 200f;
    public float maxSpeed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
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
        rb.AddForce(-transform.up * moveForce);
    }

    void LimitMaxSpeed()
    {
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}

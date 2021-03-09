using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
       
    private Vector2 mousePos;
    private Vector2 gunPos;
    private Rigidbody2D rb;
    public GameObject gun;
    public GameObject bullet;
    public bool positionLock; 
    public float maxSpeed = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        positionLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        MouseLook();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            LockPosition();
        }
        else
        {
            LimitMaxSpeed();
        }
    }

    void MouseLook()
    {
        mousePos = Input.mousePosition;
        gunPos = Camera.main.WorldToScreenPoint(gun.transform.position);
        Vector3 aimDir = gunPos - mousePos;
        float dirAngle = Mathf.Atan2(aimDir.y,aimDir.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0,0,dirAngle-90);
    }

    void LimitMaxSpeed()
    {
        positionLock = false;
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    void LockPosition()
    {
        positionLock = true;
        rb.velocity = rb.velocity.normalized * 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.AddForce(collision.contacts[0].normal * 500f);
    }
}

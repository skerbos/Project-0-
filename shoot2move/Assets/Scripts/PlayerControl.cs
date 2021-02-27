using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
       
    private Vector3 mousePos;
    private Vector3 gunPos;
    private Rigidbody rb;
    public GameObject gun;
    public GameObject bullet;
    public float recoilForce = 200f;
    public float maxSpeed = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseLook();
        Shoot();
    }

    void FixedUpdate()
    {
        LimitMaxSpeed();
    }

    void MouseLook()
    {
        mousePos = Input.mousePosition;
        gunPos = Camera.main.WorldToScreenPoint(gun.transform.position);
        Vector3 aimDir = gunPos - mousePos;
        float dirAngle = Mathf.Atan2(aimDir.y,aimDir.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0,0,dirAngle-90);
    }

    void Shoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.AddForce(gun.transform.up * recoilForce);
            Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        }
    }

    void LimitMaxSpeed()
    {
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity= rb.velocity.normalized * maxSpeed;
        }
    }
}

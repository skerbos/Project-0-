using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour
{
       
    private Vector2 mousePos;
    private Vector2 gunPos;
    private Rigidbody2D rb;
    private GameObject playerCamera;
    private float iFramesTime = 0.5f;
    private bool isAlive = true;
    public GameObject gun;
    public GameObject bullet;
    public GameObject playerDamageParticles;
    public GameObject lockSprite;
    public bool positionLock; 
    public float maxSpeed = 1000f;
    public float dirAngle;
    public int hitsRemaining = 3;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("CameraHolder");
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
            lockSprite.SetActive(true);
        }
        else
        {
            LimitMaxSpeed();
            lockSprite.SetActive(false);
        }
    }

    void MouseLook()
    {
        mousePos = Input.mousePosition;
        gunPos = Camera.main.WorldToScreenPoint(gun.transform.position);
        Vector3 aimDir = mousePos - gunPos;
        dirAngle = Mathf.Atan2(aimDir.y,aimDir.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0,0,dirAngle);
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

    void isDamaged()
    {
        playerCamera.GetComponent<CameraControl>().cameraShake(0.1f, 1f);
        GameObject playerDeathParticlesClone = Instantiate(playerDamageParticles, transform);
        Destroy(playerDeathParticlesClone, 0.2f);
        hitsRemaining -= 1;
        if (hitsRemaining <= 0)
        {
            gameObject.SetActive(false);
            isAlive = false;
            SceneManager.LoadScene("death");

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.AddForce(collision.contacts[0].normal * 500f);
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyBullet"))
        {
            isDamaged();
        }
    }
}

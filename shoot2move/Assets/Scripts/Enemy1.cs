using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private Vector2 playerPos;
    private Vector2 selfPos;
    private Rigidbody2D rb;
    public GameObject player;
    public float moveForce = 10f;
    public float maxSpeed = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        TrackPlayer();
        MoveToPlayer();
    }

    void TrackPlayer()
    {
        playerPos = Camera.main.WorldToScreenPoint(player.transform.position);
        selfPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 playerDir = playerPos - selfPos;
        float playerAngle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,playerAngle-90);

    }

    void MoveToPlayer()
    {
        rb.AddForce(transform.up * moveForce);
    }

}

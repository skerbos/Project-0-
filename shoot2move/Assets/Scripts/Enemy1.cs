using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private Vector3 playerPos;
    private Rigidbody rb;
    public GameObject player;
    public float moveForce = 10f;
    public float maxSpeed = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TrackPlayer();
        MoveToPlayer();
    }

    void TrackPlayer()
    {
        playerPos = player.transform.position;
        Vector3 playerDir = playerPos - transform.position;
        float playerAngle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,playerAngle-90);

    }

    void MoveToPlayer()
    {
        rb.AddForce(transform.up * moveForce);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float smoothSpeed = 10f;
    public Vector3 offset;
    private GameObject player;
    private float shakeTimeRemaining;
    private float shakePower;
    private float shakeFadeTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        smoothFollow();
    }

    void smoothFollow()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, smoothSpeed*Time.deltaTime);
    }

    public void cameraShake(float duration, float power)
    {
        shakeTimeRemaining = duration;
        shakePower = power;

        shakeFadeTime = power / duration;

        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            float xShake = Random.Range(-1f, 1f) * shakePower;
            float yShake = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xShake, yShake, 0);

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);
        }
    }
}

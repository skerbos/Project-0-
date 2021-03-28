using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlayerSprites : MonoBehaviour
{
    public GameObject gunPivot;
    public GameObject playerSprite;
    public GameObject playerGun;
    public GameObject headBone;
    private PlayerControl pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        float headAngle = Mathf.Clamp(pc.dirAngle, -60f, 60f);
        if (pc.dirAngle >= 90f || pc.dirAngle <= -90f)
        {
            playerSprite.transform.rotation = Quaternion.Euler(0, 180, 0);
            playerGun.GetComponent<SpriteRenderer>().flipY = true;

        }
        else if (pc.dirAngle <= 90f || pc.dirAngle >= -90f)
        {
            playerSprite.transform.rotation = Quaternion.Euler(0, 0, 0);
            playerGun.GetComponent<SpriteRenderer>().flipY = false;
        }
    }
}

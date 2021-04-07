using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockSpriteSpin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spin();
    }

    void Spin()
    {
        transform.rotation *= Quaternion.Euler(0, 0, 2f);
    }
}

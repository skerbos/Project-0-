using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKMovement : MonoBehaviour
{
    public GameObject desiredObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = desiredObject.transform.position;
    }

}

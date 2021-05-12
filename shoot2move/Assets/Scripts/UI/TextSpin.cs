using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSpin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spin();
        seizure();
    }

    void Spin()
    {
        transform.rotation *= Quaternion.Euler(0, 1f, 0);
    }

    void seizure()
    {
        transform.GetComponent<Text>().color = Random.ColorHSV();
    }
}

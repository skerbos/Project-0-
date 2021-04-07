using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public float countdownTime;
    private int currentTime;
    public Text countdownDisplay;

    private void Start()
    {
        
    }

    private void Update()
    {
        CountdownToStart();
    }

    void CountdownToStart()
    {
        gameObject.SetActive(true);
        if (countdownTime > 1)
        {
            currentTime = (int)countdownTime;
            countdownDisplay.text = currentTime.ToString();
            countdownTime -= Time.deltaTime;
        }
        else if (countdownTime > 0)
        {
            countdownDisplay.text = "START!";
            countdownTime -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}

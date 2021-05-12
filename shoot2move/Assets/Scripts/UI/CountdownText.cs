using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownText : MonoBehaviour
{
    public float countdownTime;
    private int currentTime;
    private GameObject gameManager;
    public Text countDownText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        transform.SetParent(GameObject.Find("Canvas").transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector2(0f, 250);
        CountdownToStart();
    }

    void CountdownToStart()
    {
        if (countdownTime > 1)
        {
            currentTime = (int)countdownTime;
            transform.GetComponent<Text>().text = "WAVE " + gameManager.GetComponent<EnemySpawn>().currentWave.ToString(); //currentTime.ToString();
            countdownTime -= Time.deltaTime;
        }
        else if (countdownTime > 0)
        {
            transform.GetComponent<Text>().text = "START!";
            countdownTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

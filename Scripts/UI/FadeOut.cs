using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{

    public float fadeOutTime = 0.3f;
    private float startTime;
    private Text text;
    private Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        text = gameObject.GetComponent<Text>();
        originalColor = text.color;
    }

    // Update is called once per frame
    void Update()
    {
        TextFade();
    }

    public void TextFade()
    {
        float currentTime = Time.time;
        text.color = Color.Lerp(originalColor, Color.clear, EasingFade());
    }

    public float EasingFade()
    {
        float currentTime = Time.time;
        return Mathf.Pow(((currentTime - startTime) / fadeOutTime), 4);
    }
}

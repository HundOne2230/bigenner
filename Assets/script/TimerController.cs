using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text timerText;
    public static bool LimitFlag;
    public float totalTime;
    public Text comment;
    int seconds;

    // Use this for initialization
    void Start()
    {
        LimitFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        seconds = (int)totalTime;
        timerText.text = seconds.ToString();
        if (totalTime <= 0)
        {
            LimitFlag = false;
        }

    }
}
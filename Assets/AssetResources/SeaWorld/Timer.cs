using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public TextMeshPro TimerText;
    public TextMeshPro NotificationText;

    private string NotificationName = "NotificationText";
    float InitialNotificationTime = 5.0f;
    float TimeLeft = 59.0f;

    // Start is called before the first frame update
    void Start()
    {
        TimerText = GetComponent<TextMeshPro>();
        NotificationText = GameObject.Find(NotificationName).GetComponent<TextMeshPro>();

        NotificationText.text = "Wait a while. \nPlease walking around";
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        InitialNotificationTime -= Time.deltaTime;

        if (InitialNotificationTime < 0.0)
        {
            NotificationText.text = "";
        }

        if (TimeLeft < 0.0)
        {
            TimerText.text = "0:00";
            NotificationText.text = "Let's move on to next stage!";
        }
        else
        {
            TimerText.text = Math.Floor(TimeLeft / 60).ToString("F0") + ":" + (TimeLeft % 60).ToString("00");
        }
    }
}

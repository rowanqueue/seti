using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    Text timeText;
    public int hour;
    public int minute;
    public float nextMinute;
    // Start is called before the first frame update
    public void Awake()
    {
        nextMinute = Time.time+60;
        hour = 2;
        minute = 0;
        timeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "0" + hour + ":";
        if(minute < 10)
        {
            timeText.text += "0";
        }
        timeText.text += "" + minute;
        if (Time.time > nextMinute)
        {
            minute++;
            nextMinute = Time.time + 60;
        }
    }
}

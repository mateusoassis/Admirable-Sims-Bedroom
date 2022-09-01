using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeHandler : MonoBehaviour
{
    [SerializeField] private int hours;
    [SerializeField] private int minutes;
    [SerializeField] private float timeMultiplier; // every X seconds, 1 minute passes
    private float timer;
    [SerializeField] private TextMeshProUGUI timeTextHolder;

    void Start()
    {
        timeTextHolder.text = hours.ToString("00") + ":" + minutes.ToString("00");
        timer = timeMultiplier;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            UpdateTime();
        }
    }

    private void UpdateTime()
    {
        minutes++;
        if(minutes == 60)
        {
            minutes = 0;
            hours++;
            if(hours == 24)
            {
                hours = 0;
            }
        }
        timeTextHolder.text = hours.ToString("00") + ":" + minutes.ToString("00");
        timer = timeMultiplier;
    }
}

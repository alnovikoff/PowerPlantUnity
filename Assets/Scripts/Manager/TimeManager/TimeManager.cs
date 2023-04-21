using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    public static int Minute { get; private set; }
    public static int Hour { get; private set; }

    private float minuteToRealTime = 0.5f;
    private float timer;

    [SerializeField] private TMP_Text timeTxt;
    [SerializeField] private TMP_Text dayTxt;

    public string[] WeekDays = new string[7] { "Monday", "Tuesday", "Wednesday", "Thirsday", "Friday", "Sunday", "Saturday" };
    private int dayIndex = 0;

    void Start()
    {
        Minute = 0;
        Hour = 10;
        timer = minuteToRealTime;
    }

    private void OnEnable()
    {
        OnMinuteChanged += UpdateTimeUI;
        OnHourChanged += UpdateTimeUI;
    }

    private void OnDisable()
    {
        OnMinuteChanged -= UpdateTimeUI;
        OnHourChanged -= UpdateTimeUI;
    }

    public void Clock()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Minute++;
            OnMinuteChanged?.Invoke();
            if (Minute >= 60)
            {
                Hour++;
                Minute = 0;
                OnHourChanged?.Invoke();
                if(Hour >= 24)
                {
                    Hour = 0;
                    dayIndex++;
                    if(dayIndex >= 7)
                    {
                        dayIndex = 0;
                    }
                }
            }
            timer = minuteToRealTime;
        }
    }

    private void UpdateTimeUI()
    {
        dayTxt.text = WeekDays[dayIndex];
        timeTxt.text = $"{Hour:00}:{Minute:00}";
    }
}

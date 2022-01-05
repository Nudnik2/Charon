using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;
    public static Action OnDayChanged;

    public static int Minute { get; private set; }
    public static int Hour { get; private set; }
    public static int Day { get; private set; }

    private DaysOfTheWeek dayOfTheWeek;

    private float minuteToRealTime = 0.5f; //Every half a second real time = minute gametime
    private float timer;


    private enum DaysOfTheWeek
    {
        Sunday = 0,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
    }

    // Start is called before the first frame update
    void Start()
    {
        Minute = 0;
        Hour = 10;
        Day = 6;        
       
        dayOfTheWeek = (DaysOfTheWeek)Day;
        timer = minuteToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Minute++;
            if(Minute >= 60)
            {
                Hour++;
                if(Hour == 24)
                {
                    Hour = 0;
                    Day++;
                    if (Day > 6)
                        Day = 0;
                    dayOfTheWeek = (DaysOfTheWeek)Day;
                    OnDayChanged?.Invoke();
                }
                OnHourChanged?.Invoke();
                Minute = 0;
            }

            OnMinuteChanged?.Invoke();
            timer = minuteToRealTime;
        }
    }
}

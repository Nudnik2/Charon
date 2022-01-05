using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIClock : MonoBehaviour
{
    [SerializeField]
    private TMP_Text clockText;

    private string[] daysOfTheWeek = new string[7] {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};


    // Start is called before the first frame update
    void Start()
    {
        TimeManager.OnMinuteChanged += UpdateTime;
    }

    void UpdateTime()
    {
        clockText.text = $"{daysOfTheWeek[TimeManager.Day]} - {TimeManager.Hour:00}:{TimeManager.Minute:00}";
    }
}

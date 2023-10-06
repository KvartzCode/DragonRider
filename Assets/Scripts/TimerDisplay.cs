using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] ScoreWheel minuteWheel;
    [SerializeField] ScoreWheel leftSecondWheel;
    [SerializeField] ScoreWheel rightSecondWheel;


    // Start is called before the first frame update
    void Start()
    {
        TimeSpan ts = TimeSpan.FromSeconds(300);
        Debug.Log(ts.ToString());
    }


    public void SetTime(int secondsTotal)
    {
        TimeSpan ts = TimeSpan.FromSeconds(secondsTotal);
        minuteWheel.UpdateValue(ts.Minutes);
        leftSecondWheel.UpdateValue(ts.Seconds.ToArray()[0]);
        rightSecondWheel.UpdateValue(ts.Seconds.ToArray()[1]);
    }
}

using System;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] ScoreWheel minuteWheel;
    [SerializeField] ScoreWheel leftSecondWheel;
    [SerializeField] ScoreWheel rightSecondWheel;


    void Start()
    {
        TimeSpan ts = TimeSpan.FromSeconds(300);
        Debug.Log(ts.ToString());
    }

    public void SetTime(int secondsTotal)
    {
        TimeSpan ts = TimeSpan.FromSeconds(secondsTotal);
        int[] seconds = ts.Seconds.ToArray();

        if (seconds.Length < 2)
            seconds = new int[] { 0, seconds[0] };

        minuteWheel.UpdateValue(ts.Minutes);
        leftSecondWheel.UpdateValue(seconds[0]);
        rightSecondWheel.UpdateValue(seconds[1]);
    }
}

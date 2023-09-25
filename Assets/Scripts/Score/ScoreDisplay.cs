using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public int Score { get; private set; }

    [SerializeField, Tooltip("Order by right to left. Eg: index 0 is the rightmost number, index 1 is the second rightmost number, etc.")]
    List<ScoreWheel> wheels = new List<ScoreWheel>();


    //int t = 1;
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //        SetScore((int)Mathf.Pow(2, t++));
    //}



    public void SetScore(int value)
    {
        if (Score >= Mathf.Pow(10, wheels.Count)) // if score is already higher than can be displayed.
            return;

        Score = value;
        RotateWheels(Score);
    }

    public void AddScore(int value)
    {
        if (Score >= Mathf.Pow(10, wheels.Count)) // if score is already higher than can be displayed.
            return;

        Score += value;
        RotateWheels(Score);
    }

    void RotateWheels(int value)
    {
        if (value >= Mathf.Pow(10, wheels.Count))
        {
            foreach (var wheel in wheels)
            {
                wheel.UpdateValue(9);
            }
        }
        else
        {
            int[] result = value.ToArray().Reverse().ToArray();
            for (int i = 0; i < wheels.Count; i++)
            {
                int number = i < result.Length ? result[i] : 0;
                wheels[i].UpdateValue(number);
            }
        }
    }
}

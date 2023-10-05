using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int Score { get; private set; }

    [SerializeField] ScoreDisplay scoreDisplay;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        scoreDisplay?.AddScore(scoreToAdd);
        Debug.Log(Score);
    }
}

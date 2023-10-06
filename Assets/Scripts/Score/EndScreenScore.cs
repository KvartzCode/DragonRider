using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreenScore : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;


    void Start()
    {
        if (!scoreText)
            scoreText = GetComponent<TMP_Text>();

        scoreText.text = ScoreManager.Instance?.Score.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float Timer { get; private set; } = 300;


    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
            EndGame();
    }

    private void EndGame()
    {
        //TODO: end game stuff.
    }
}

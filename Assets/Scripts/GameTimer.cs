using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float Timer { get; private set; } = 300;

    private int extraTime = 300;

    [SerializeField] TimerDisplay timerDisplay;

    //public float Timer = 20; //For testing

    void Update()
    {
        Timer -= Time.deltaTime;

        if (extraTime - Timer > 1)
        {
            extraTime = (int)Timer;
            timerDisplay.SetTime(extraTime);
        }

        if (Timer <= 0)
            EndGame();
    }

    private void EndGame()
    {
        SimpleGameStateManager.instance.ChangeGameState(Gamestate.GameOver);
        //TODO: end game stuff.
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float Timer { get; private set; } = 300;

    //public float Timer = 20; //For testing

    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
            EndGame();
    }

    private void EndGame()
    {
        SimpleGameStateManager.instance.ChangeGameState(Gamestate.GameOver);
        //TODO: end game stuff.
    }
}

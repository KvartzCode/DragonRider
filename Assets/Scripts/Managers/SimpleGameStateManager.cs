using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gamestate { StartState, GameActiveState, GameOverState}




public class SimpleGameStateManager : MonoBehaviour
{
    public static SimpleGameStateManager instance;
    public Gamestate currentState;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    private void Start()
    {
        ChangeGameState(Gamestate.StartState);
    }



    public void StartState()
    {
        //Add start gamestuff here
        Debug.Log("Starting");
        ChangeGameState(Gamestate.GameActiveState);   
    }

    private void Update()
    {
       
    }

    public void GameActiveState()
    {
        Debug.Log("Runnning");
    }

    public void GameOver()
    {

    }

    public void ChangeGameState(Gamestate state)
    {
        currentState = state;

        switch (currentState) 
        {
            case Gamestate.StartState:
                StartState();
                break;
            case Gamestate.GameActiveState:
                GameActiveState();
                break;
            case Gamestate.GameOverState:
                //TODO add methods for gameover
                break;

        }
    }
}

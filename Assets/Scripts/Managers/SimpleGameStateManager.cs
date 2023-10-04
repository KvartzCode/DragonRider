using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Gamestate { Menu, GameActive, GameOver}




public class SimpleGameStateManager : MonoBehaviour
{
    public static SimpleGameStateManager instance;
    public Gamestate currentState;

    public string[] sceneNames;

    public int accumulatedScore;


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
       
    }


    public void StartMenu()
    {
        //Add start gamestuff here
        Debug.Log("Starting");
        ChangeGameState(Gamestate.GameActive);   
    }

    public void StartGame()
    {
        //SceneManager.LoadScene(1);
    }

    public void SetGameActive()
    {
        Debug.Log("Runnning");
    }

    public void GameOver()
    {
        accumulatedScore = ScoreManager.Instance.score;
        SceneManager.LoadScene(3);
    }



    public void ChangeGameState(Gamestate state)
    {
        currentState = state;

        switch (currentState) 
        {
            case Gamestate.Menu:
                StartMenu();
                break;
            case Gamestate.GameActive:
                SetGameActive();
                break;
            case Gamestate.GameOver:
                //TODO add methods for gameover
                GameOver();
                break;
        }
    }
}

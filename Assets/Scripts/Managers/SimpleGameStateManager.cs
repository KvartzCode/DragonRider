using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Gamestate { Menu, GameActive, GameOver }

public class SimpleGameStateManager : MonoBehaviour
{
    public static SimpleGameStateManager instance;
    public Gamestate currentState;

    public string menuScene, gameScene, gameOverScene;

    public int accumulatedScore;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }


    public void StartMenu()
    {
        //Add start gamestuff here
        if (menuScene != null)
        {
            SceneManager.LoadScene(menuScene);
        }
    }

    public void SetGameActive()
    {
        if (gameScene != null)
        {
            SceneManager.LoadScene(gameScene);
        }
    }

    public void GameOver()
    {
        accumulatedScore = ScoreManager.Instance.score;

        if (gameOverScene != null)
        {
            SceneManager.LoadScene(gameOverScene);
        }
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


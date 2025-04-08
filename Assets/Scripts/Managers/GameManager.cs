using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum GameState
    {
        MainMenu,
        Playing,
        Pause,
        GameOver,
        Win
    }

    public GameState currentGameState;

    void OnEnable()
    {
        PlayerHealth.OnGameOver += () => ChangeGameState(GameState.GameOver);
        PlayerController.OnPause += Pause;
        WinZone.OnWin += () => ChangeGameState(GameState.Win);
    }

    void OnDisable()
    {
        PlayerHealth.OnGameOver -= () => ChangeGameState(GameState.GameOver);
        PlayerController.OnPause -= Pause;
        WinZone.OnWin -= () => ChangeGameState(GameState.Win);
    }

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        currentGameState = GameState.Playing;
    }

    void ChangeGameState(GameState state)
    {
        currentGameState = state;
    }

    public void Pause()
    {
        if (currentGameState == GameState.Playing) 
        {
            currentGameState = GameState.Pause;
			
    		Time.timeScale = 0;
		}
        else if(currentGameState == GameState.Pause)
        {
            currentGameState = GameState.Playing;
			
			Time.timeScale = 1;
		}
    }
}

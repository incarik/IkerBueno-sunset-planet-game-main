using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementManager : MonoBehaviour
{
    private int _sceneIndex;

    void Awake()
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    /*void OnEnable()
    {
        LevelFinisher.OnLevelFinished += LoadNextLevel;
    }

    void OnDisable()
    {
        LevelFinisher.OnLevelFinished -= LoadNextLevel;
    }*/

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ReloadLevel()
    {
        GameManager.instance.currentGameState = GameManager.GameState.Playing;
        //AudioManager.Instance.ChangeMusic(AudioManager.Instance.gameMusic);
        SceneManager.LoadScene(_sceneIndex);
    }
    
    /*public void LoadNextLevel()
    {
        GameManager.Instance.currentGameState = GameManager.GameState.CameraAnimation;
        SceneManager.LoadScene(_sceneIndex + 1);
    }*/

    public void LoadMainMenu()
    {        
        GameManager.instance.currentGameState = GameManager.GameState.MainMenu;
        //AudioManager.Instance.ChangeMusic(AudioManager.Instance.mainMenuMusic);
        //Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }  

    /*public void LoadNewGame(int sceneIndex)
    {
        GameManager.Instance.currentGameState = GameManager.GameState.CameraAnimation;
        AudioManager.Instance.ChangeMusic(AudioManager.Instance.gameMusic);
        SceneManager.LoadScene(sceneIndex);
    }*/
}

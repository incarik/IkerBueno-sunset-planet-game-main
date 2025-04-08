using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private GameObject _winCanvas;

    void OnEnable()
    {
        PlayerHealth.OnGameOver += () => ChangeCanvasState(_gameOverCanvas);
        PlayerController.OnPause += () => ChangeCanvasState(_pauseCanvas);
        WinZone.OnWin += () => ChangeCanvasState(_winCanvas);
    }

    void OnDisable()
    {
        PlayerHealth.OnGameOver -= () => ChangeCanvasState(_gameOverCanvas);
        PlayerController.OnPause -= () => ChangeCanvasState(_pauseCanvas);
        WinZone.OnWin -= () => ChangeCanvasState(_winCanvas);
    }

    void ChangeCanvasState(GameObject canvas)
    {
        canvas.SetActive(!canvas.activeSelf);
    }
}

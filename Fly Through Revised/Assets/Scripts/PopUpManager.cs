using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public GameObject GameClearCanvas;
    public GameObject GameOverCanvas;
    public GameObject PauseCanvas;
    public GameObject PauseButtonCanvas;

    void Update()
    {
        switch (GameManager.instance.getCurrentState())
        {
            case GameManager.GameState.Game:
                GameClearCanvas.SetActive(false);
                GameOverCanvas.SetActive(false);
                PauseCanvas.SetActive(false);
                PauseButtonCanvas.SetActive(true);
                break;
            case GameManager.GameState.LevelClear:
                GameClearCanvas.SetActive(true);
                GameOverCanvas.SetActive(false);
                PauseCanvas.SetActive(false);
                PauseButtonCanvas.SetActive(false);
                break;
            case GameManager.GameState.GameOver:
                GameClearCanvas.SetActive(false);
                GameOverCanvas.SetActive(true);
                PauseCanvas.SetActive(false);
                PauseButtonCanvas.SetActive(false);
                break;
            case GameManager.GameState.Paused:
                GameClearCanvas.SetActive(false);
                GameOverCanvas.SetActive(false);
                PauseCanvas.SetActive(true);
                PauseButtonCanvas.SetActive(false);
                break;
            case GameManager.GameState.TitleScreen:
                GameClearCanvas.SetActive(false);
                GameOverCanvas.SetActive(false);
                PauseCanvas.SetActive(false);
                PauseButtonCanvas.SetActive(false);
                break;
            default:
                Debug.Log("In a unexpected state");
                break;
        }
    }
}

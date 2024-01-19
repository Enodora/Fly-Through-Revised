using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    private GameState state;
    //public static event Action<GameState> OnGameStateChanged;

    public GameObject selectedShipPrefab;
    [HideInInspector] public int selectedLevel;
    [HideInInspector] public int highestLevel = 1;

    // private constructor so other classes won't be able to instantiate this class
    private GameManager() { }

    // Possible states within the game
    public enum GameState
    {
        TitleScreen,
        Transition,
        MoveForward,
        Game,
        Paused,
        LevelClear,
        GameOver
    }

    // Sets game state to title screen
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            UpdateGameState(GameState.TitleScreen);
        } else
        {
            UpdateGameState(GameState.Game);
        }
        
    }
    // Destroy Duplicate GameManager Object
    void Awake()
    {
        highestLevel = PlayerPrefs.GetInt("LevelUnlocked", 1);

        GameObject[] gameManagers = GameObject.FindGameObjectsWithTag("GameManager");

        if (instance != null && instance != this)
        {
            Destroy(this);
        } else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public GameState getCurrentState()
    {
        return state;
    }

    // Updates game state
    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.TitleScreen:
                break;
            case GameState.Game:
                break;
            case GameState.LevelClear:
                break;
            case GameState.GameOver:
                break;
            case GameState.Transition:
                break;
            case GameState.MoveForward:
                break;
            case GameState.Paused:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        //OnGameStateChanged?.Invoke(newState);
    }
}

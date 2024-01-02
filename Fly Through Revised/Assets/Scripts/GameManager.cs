using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager singleton;

    private GameState state;
    private GameObject selectedShip;
    public static event Action<GameState> OnGameStateChanged;

    // private constructor so other classes won't be able to instantiate this class
    private GameManager() { }

    // Possible states within the game
    public enum GameState
    {
        TitleScreen,
        Game,
        GameOver
    }

    // Sets game state to title screen
    void Start()
    {
        UpdateGameState(GameState.TitleScreen);
    }

    // Destroy Duplicate GameManager Object
    void Awake()
    {
        GameObject[] gameManagers = GameObject.FindGameObjectsWithTag("GameManager");

        if (gameManagers.Length > 1)
        {
            Destroy(this.gameObject);
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
            case GameState.GameOver:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    // Since the object is a singleton, returns itself
    public static GameManager getInstance ()
    {
        if (singleton == null)
        {
            singleton = new GameManager();
        }
        return singleton;
    }

    public void setSelectedShip(GameObject ship)
    {
        selectedShip = ship;
    }

    public GameObject getSelectedShip()
    {
        return selectedShip;
    }
}

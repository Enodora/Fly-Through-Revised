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

    /// <summary>
    /// private constructor so other classes won't be able to instantiate this class
    /// </summary>
    private GameManager() { }

    /// <summary>
    /// Possible states within the game
    /// </summary>
    public enum GameState
    {
        TitleScreen,
        Game,
        GameOver
    }

    /// <summary>
    /// Sets game state to title screen
    /// </summary>
    void Start()
    {
        UpdateGameState(GameState.TitleScreen);
    }

    /// <summary>
    /// Destroy Duplicate GameManager Object
    /// </summary>
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

    /// <summary>
    /// Updates game state
    /// </summary>
    /// <param name="newState"></param>
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

    /// <summary>
    /// Since the object is a singleton, returns itself
    /// </summary>
    /// <returns> this </returns>
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

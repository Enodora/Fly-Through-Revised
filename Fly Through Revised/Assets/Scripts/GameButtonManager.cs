using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        GameManager.instance.UpdateGameState(GameManager.GameState.Game);
    }

    public void Retry()
    {
        GameManager.instance.UpdateGameState(GameManager.GameState.Game);
        GameObject.FindWithTag("Player").transform.position = GameObject.Find("Spawn SpaceShip").transform.position;

        foreach (GameObject star in GameObject.FindGameObjectsWithTag("Star"))
        {
            Destroy(star);
        }

        SpawnStars respawnStars = GameObject.Find("StarManager").GetComponent<SpawnStars>();
        respawnStars.createStars();

        SpaceShipController shipController = GameObject.FindWithTag("Player").transform.GetChild(0).gameObject.GetComponent<SpaceShipController>();
        shipController.resetStarValues();
    }

    public void Menu()
    {
        GameManager.instance.UpdateGameState(GameManager.GameState.TitleScreen);
        GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadNextLevel(0);
    }

    public void Pause()
    {
        GameManager.instance.UpdateGameState(GameManager.GameState.Paused);
    }
}

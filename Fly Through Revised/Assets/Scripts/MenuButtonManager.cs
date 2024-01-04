using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonManager : MonoBehaviour
{
    private Animator menuAnim;
    private Animator shipAnim;
    private Animator portalAnim;
    private MenuState currentMenu;

    public Text levelLabel;

    private enum MenuState
    {
        MainMenu,
        Settings,
        Credit,
        Levels
    }

    void Start()
    {
        menuAnim = GameObject.Find("RightPiviot").GetComponent<Animator>();
        portalAnim = GameObject.Find("Portal blue (Entrance)").GetComponent<Animator>();

        choseLevel(GameManager.highestLevel);
    }

    public void pressedPlay()
    {
        shipAnim = GameObject.FindWithTag("Player").transform.GetChild(0).gameObject.GetComponent<Animator>();
        shipAnim.SetBool("Play", true);

        GameManager.getInstance().UpdateGameState(GameManager.GameState.Game);
    }

    public void pressedSettings()
    {
        currentMenu = MenuState.Settings;
        menuAnim.SetBool("Settings", true);
        portalAnim.SetBool("Close", true);
    }

    public void pressedCredit()
    {
        currentMenu = MenuState.Credit;
        menuAnim.SetBool("Credit", true);
        portalAnim.SetBool("Close", true);
    }

    public void pressedLevels()
    {
        currentMenu = MenuState.Levels;
        menuAnim.SetBool("Levels", true);
        portalAnim.SetBool("Close", true);
    }

    public void pressedRightShip()
    {
        ShipSelect.rightClicked = true;
    }

    public void pressedLeftShip()
    {
        ShipSelect.leftClicked = true;
    }

    public void pressedBack()
    {
        portalAnim.SetBool("Close", false);

        switch (currentMenu)
        {
            case MenuState.Settings:
                currentMenu = MenuState.MainMenu;
                menuAnim.SetBool("Settings", false);
                break;
            case MenuState.Credit:
                currentMenu = MenuState.MainMenu;
                menuAnim.SetBool("Credit", false);
                break;
            case MenuState.Levels:
                currentMenu = MenuState.MainMenu;
                menuAnim.SetBool("Levels", false);
                break;
            case MenuState.MainMenu:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(currentMenu), currentMenu, null);
        }
    }

    public void choseLevel(int levelNum)
    {
        GameManager.selectedLevel = levelNum; 
        levelLabel.text = "Level: " + GameManager.selectedLevel;

        pressedBack();
    }
}

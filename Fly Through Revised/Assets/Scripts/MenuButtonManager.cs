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
        menuAnim = GameObject.Find("Parent").GetComponent<Animator>();
        portalAnim = GameObject.Find("Portal blue (Entrance)").GetComponent<Animator>();

        choseLevel(GameManager.instance.highestLevel, false);
    }

    public void pressedPlay()
    {
        shipAnim = GameObject.FindWithTag("Player").transform.GetChild(0).gameObject.GetComponent<Animator>();
        shipAnim.SetBool("Play", true);

        GameManager.instance.UpdateGameState(GameManager.GameState.Transition);
        AudioManager.instance.buttonSFX();
    }

    public void pressedSettings()
    {
        currentMenu = MenuState.Settings;
        menuAnim.SetBool("Settings", true);
        portalAnim.SetBool("Close", true);

        AudioManager.instance.buttonSFX();
    }

    public void pressedCredit()
    {
        currentMenu = MenuState.Credit;
        menuAnim.SetBool("Credit", true);
        portalAnim.SetBool("Close", true);

        AudioManager.instance.buttonSFX();
    }

    public void pressedLevels()
    {
        currentMenu = MenuState.Levels;
        menuAnim.SetBool("Levels", true);
        portalAnim.SetBool("Close", true);

        AudioManager.instance.buttonSFX();
    }

    public void pressedRightShip()
    {
        ShipSelect.rightClicked = true;

        AudioManager.instance.buttonSFX();
    }

    public void pressedLeftShip()
    {
        ShipSelect.leftClicked = true;
        
        AudioManager.instance.buttonSFX();
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

        AudioManager.instance.buttonSFX();
    }

    public void choseLevel(int levelNum)
    {
        GameManager.instance.selectedLevel = levelNum; 
        levelLabel.text = "Level: " + GameManager.instance.selectedLevel;

        pressedBack();
    }
    public void choseLevel(int levelNum, bool makeSound)
    {
        GameManager.instance.selectedLevel = levelNum;
        levelLabel.text = "Level: " + GameManager.instance.selectedLevel;
    }
}

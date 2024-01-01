using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{
    private Animator menuAnim;
    private MenuState currentMenu;

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
    }

    public void pressedPlay()
    {
        Debug.Log("Play");
    }

    public void pressedSettings()
    {
        Debug.Log("Settings");
        currentMenu = MenuState.Settings;
        menuAnim.SetBool("Settings", true);
    }

    public void pressedCredit()
    {
        Debug.Log("Credit");
        currentMenu = MenuState.Credit;
        menuAnim.SetBool("Credit", true);
    }

    public void pressedLevels()
    {
        Debug.Log("Levels");
        currentMenu = MenuState.Levels;
        menuAnim.SetBool("Levels", true);
    }

    public void pressedRightShip()
    {
        Debug.Log("Right");
        ShipSelect.rightClicked = true;
    }

    public void pressedLeftShip()
    {
        Debug.Log("Left");
        ShipSelect.leftClicked = true;
    }

    public void pressedBack()
    {
        Debug.Log("Back");
        
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
            default:
                throw new ArgumentOutOfRangeException(nameof(currentMenu), currentMenu, null);
        }
    }
}

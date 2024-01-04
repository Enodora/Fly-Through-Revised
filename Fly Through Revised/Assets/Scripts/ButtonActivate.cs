using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivate : MonoBehaviour
{
    private Button[] buttons;

    // MenuButton Tag to exclude level buttons
    void Start()
    {
        buttons = new Button[GameObject.FindGameObjectsWithTag("MenuButton").Length];

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("MenuButton").Length; i++)
        {
            buttons[i] = GameObject.FindGameObjectsWithTag("MenuButton")[i].GetComponent<Button>();
        }
    }

    public void enableAllButtons()
    {
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }

    public void disableAllButtons()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
    }
}

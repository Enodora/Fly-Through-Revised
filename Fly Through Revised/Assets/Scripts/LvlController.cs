using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlController : MonoBehaviour
{
    private GameObject[] levelButtons;
    private GameObject[] threeStars;

    private int[,] collectedStars;

    // Start is called before the first frame update
    void Start()
    {
        levelButtons = GameObject.FindGameObjectsWithTag("LevelButton");
        threeStars = GameObject.FindGameObjectsWithTag("ThreeStars");

        collectedStars = new int[,]{
            {PlayerPrefs.GetInt("Level1First", 0), PlayerPrefs.GetInt("Level1Middle", 0),PlayerPrefs.GetInt("Level1Last", 0)}, //Level1
            {PlayerPrefs.GetInt("Level2First", 0), PlayerPrefs.GetInt("Level2Middle", 0),PlayerPrefs.GetInt("Level2Last", 0)}, //Level2
            {PlayerPrefs.GetInt("Level3First", 0), PlayerPrefs.GetInt("Level3Middle", 0),PlayerPrefs.GetInt("Level3Last", 0)}, //Level3
            {PlayerPrefs.GetInt("Level4First", 0), PlayerPrefs.GetInt("Level4Middle", 0),PlayerPrefs.GetInt("Level4Last", 0)}, //Level4
            {PlayerPrefs.GetInt("Level5First", 0), PlayerPrefs.GetInt("Level5Middle", 0),PlayerPrefs.GetInt("Level5Last", 0)}, //Level5
            {PlayerPrefs.GetInt("Level6First", 0), PlayerPrefs.GetInt("Level6Middle", 0),PlayerPrefs.GetInt("Level6Last", 0)}, //Level6
            {PlayerPrefs.GetInt("Level7First", 0), PlayerPrefs.GetInt("Level7Middle", 0),PlayerPrefs.GetInt("Level7Last", 0)}, //Level7
            {PlayerPrefs.GetInt("Level8First", 0), PlayerPrefs.GetInt("Level8Middle", 0),PlayerPrefs.GetInt("Level8Last", 0)}, //Level8
            {PlayerPrefs.GetInt("Level9First", 0), PlayerPrefs.GetInt("Level9Middle", 0),PlayerPrefs.GetInt("Level9Last", 0)}, //Level9
            {PlayerPrefs.GetInt("Level10First", 0), PlayerPrefs.GetInt("Level10Middle", 0),PlayerPrefs.GetInt("Level10Last", 0)}, //Level10
            {PlayerPrefs.GetInt("Level11First", 0), PlayerPrefs.GetInt("Level11Middle", 0),PlayerPrefs.GetInt("Level11Last", 0)}, //Level11
            {PlayerPrefs.GetInt("Level12First", 0), PlayerPrefs.GetInt("Level12Middle", 0),PlayerPrefs.GetInt("Level12Last", 0)}, //Level12
        };


        for (int i = GameManager.highestLevel; i <= 11; i++)
        {
            levelButtons[i].GetComponent<Button>().interactable = false;
            levelButtons[i].transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            levelButtons[i].transform.GetChild(1).gameObject.SetActive(true);

            levelButtons[i].GetComponent<Button>().interactable = false;
        }
        for (int i = 0; i < GameManager.highestLevel; i++)
        {
            //Left Stars
            if (collectedStars[i, 0] == 1)
            {
                threeStars[i].transform.GetChild(0).gameObject.SetActive(false);
                threeStars[i].transform.GetChild(3).gameObject.SetActive(true);
            }
            else
            {
                threeStars[i].transform.GetChild(0).gameObject.SetActive(true);
                threeStars[i].transform.GetChild(3).gameObject.SetActive(false);
            }
            //Middle Stars
            if (collectedStars[i, 1] == 1)
            {
                threeStars[i].transform.GetChild(1).gameObject.SetActive(false);
                threeStars[i].transform.GetChild(4).gameObject.SetActive(true);
            }
            else
            {
                threeStars[i].transform.GetChild(1).gameObject.SetActive(true);
                threeStars[i].transform.GetChild(4).gameObject.SetActive(false);
            }
            //Right Stars
            if (collectedStars[i, 2] == 1)
            {
                threeStars[i].transform.GetChild(2).gameObject.SetActive(false);
                threeStars[i].transform.GetChild(5).gameObject.SetActive(true);
            }
            else
            {
                threeStars[i].transform.GetChild(2).gameObject.SetActive(true);
                threeStars[i].transform.GetChild(5).gameObject.SetActive(false);
            }
        }

    }
}

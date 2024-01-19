using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedMenuStarSpawn : MonoBehaviour
{
    private int[] collectedStars = new int[3];
    private GameObject leftStar;
    private GameObject middleStar;
    private GameObject lastStar;

    void Start()
    {
        collectedStars[0] = PlayerPrefs.GetInt("Level1First", 0);
        collectedStars[1] = PlayerPrefs.GetInt("Level1Middle", 0);
        collectedStars[2] = PlayerPrefs.GetInt("Level1Last", 0);

        leftStar = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        middleStar = this.gameObject.transform.GetChild(1).GetChild(0).gameObject;
        lastStar = this.gameObject.transform.GetChild(2).GetChild(0).gameObject;

        
    }

    // Update is called once per frame
    void Update()
    {
        leftStar.SetActive(false);
        middleStar.SetActive(false);
        lastStar.SetActive(false);

        if (collectedStars[0] == 1)
        {
            leftStar.SetActive(true);
        }
        if (collectedStars[1] == 1)
        {
            middleStar.SetActive(true);
        }
        if (collectedStars[2] == 1)
        {
            lastStar.SetActive(true);
        }
    }
}

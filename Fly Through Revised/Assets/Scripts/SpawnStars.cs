using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStars : MonoBehaviour
{
    public GameObject[] starPos;
    public GameObject[] stars;

    // Start is called before the first frame update
    void Start()
    {
        createStars();
    }

    public void createStars()
    {
        Instantiate(stars[0], starPos[0].transform.position, Quaternion.Euler(-90f, 0f, 0f));
        Instantiate(stars[1], starPos[1].transform.position, Quaternion.Euler(-90f, 0f, 0f));
        Instantiate(stars[2], starPos[2].transform.position, Quaternion.Euler(-90f, 0f, 0f));
        for (int i = 0; i < 3; i++)
        {
            GameObject.FindGameObjectsWithTag("Star")[i].transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }
}

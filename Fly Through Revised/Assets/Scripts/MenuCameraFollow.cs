using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraFollow : MonoBehaviour
{
    private SpaceShipController shipController;

    // Update is called once per frame
    void Update()
    {
        try {
            shipController = GameObject.FindWithTag("Player").transform.GetChild(0).gameObject.GetComponent<SpaceShipController>();
            if (GameManager.instance.getCurrentState() == GameManager.GameState.MoveForward)
            {
                this.gameObject.transform.parent = GameObject.FindWithTag("Player").transform;
            }
        } catch (NullReferenceException e)
        {
            Debug.Log("Expected Error: " + e.Message);
        } catch (Exception e)
        {
            Debug.LogError("Unexpected Error: " + e.Message);
        }
    }
}

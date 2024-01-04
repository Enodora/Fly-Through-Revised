using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMoveForward : MonoBehaviour
{
    private bool doMoveForward = false;

    [Header("Speed of moving forward")] public float speed;

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "TitleScene")
        {
            doMoveForward = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (doMoveForward)
        {
            GameManager.getInstance().selectedShip.transform.position += new Vector3(0, 0, Time.deltaTime * speed);
            Debug.Log("moveForward");
        }
    }

    public void moveForward()
    {
        doMoveForward = true;
        this.gameObject.GetComponent<Animator>().enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelect : MonoBehaviour
{
    [Header("Array of Ships")] public GameObject[] ships;
    [Header("Array of position of ships")] public GameObject[] shipPos;
    public static bool rightClicked = false;
    public static bool leftClicked = false;

    private CircularDoublyLinkedList shipLists = new CircularDoublyLinkedList();
    private LinkedListNode selectedShip;
    private GameObject leftShip;
    private GameObject mainShip;
    private GameObject rightShip;

    /// <summary>
    /// Add ships to selectable
    /// </summary>
    void Start()
    {
        foreach (GameObject ship in ships)
        {
            shipLists.add(ship);
        }

        selectedShip = shipLists.head;

        leftShip = Instantiate(selectedShip.prev.element, shipPos[0].transform.position, Quaternion.Euler(10f, -150f, 0f), this.gameObject.transform);
        mainShip = Instantiate(selectedShip.element, shipPos[1].transform.position, Quaternion.Euler(10f, -150f, 0f), this.gameObject.transform);
        rightShip = Instantiate(selectedShip.next.element, shipPos[2].transform.position, Quaternion.Euler(10f, -150f, 0f), this.gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.getInstance().getCurrentState() == GameManager.GameState.TitleScreen)
        {
            if (rightClicked)
                actionRightArrow();
            if (leftClicked)
                actionLeftArrow();
            if (rightClicked || leftClicked)
            {
                leftShip = Instantiate(selectedShip.prev.element, shipPos[0].transform.position, Quaternion.Euler(10f, -150f, 0f), this.gameObject.transform);
                mainShip = Instantiate(selectedShip.element, shipPos[1].transform.position, Quaternion.Euler(10f, -150f, 0f), this.gameObject.transform);
                rightShip = Instantiate(selectedShip.next.element, shipPos[2].transform.position, Quaternion.Euler(10f, -150f, 0f), this.gameObject.transform);
            }
            leftShip.tag = "Unselected";
            mainShip.tag = "Player";
            rightShip.tag = "Unselected";

            leftShip.transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = false;
            mainShip.transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true;
            rightShip.transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = false;

            mainShip.gameObject.transform.localScale = new Vector3(153.96f, 153.96f, 153.96f);
            leftShip.gameObject.transform.localScale = new Vector3(123.168f, 123.168f, 123.168f);
            rightShip.gameObject.transform.localScale = new Vector3(123.168f, 123.168f, 123.168f);

            rightClicked = false;
            leftClicked = false;
        } else if (GameManager.getInstance().getCurrentState() == GameManager.GameState.Game)
        {
            mainShip.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            Debug.Log("Running");
        }
    }

    public void actionRightArrow()
    {
        Destroy(leftShip);
        Destroy(mainShip);
        Destroy(rightShip);

        selectedShip = selectedShip.next;
    }
    public void actionLeftArrow()
    {
        Destroy(leftShip);
        Destroy(mainShip);
        Destroy(rightShip);

        selectedShip = selectedShip.prev;
    }
}

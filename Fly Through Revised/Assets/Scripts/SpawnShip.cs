using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShip : MonoBehaviour
{
    public float shipScale = 1;

    private GameObject ship;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(GameManager.instance.selectedShipPrefab, this.gameObject.transform.position, Quaternion.identity);

        ship = GameObject.FindWithTag("Player");

        ship.transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = false;
        ship.transform.localScale = new Vector3(shipScale, shipScale, shipScale);

        GameObject.Find("Main Camera").transform.parent = ship.transform;
    }
}

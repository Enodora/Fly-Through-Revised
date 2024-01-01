using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedListNode : MonoBehaviour
{
    public GameObject element;
    public LinkedListNode next;
    public LinkedListNode prev;

    public LinkedListNode(GameObject obj)
    {
        element = obj;
    }
}

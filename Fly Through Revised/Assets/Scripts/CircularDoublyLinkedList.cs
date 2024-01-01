using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularDoublyLinkedList : MonoBehaviour
{
    public LinkedListNode head, tail;
    public int size = 0;

    public void add(GameObject obj)
    {
        LinkedListNode newNode = new LinkedListNode(obj);
        if (size == 0)
            head = tail = newNode;
        else
        {
            LinkedListNode temp = tail;
            tail.next = newNode;
            tail = newNode;
            tail.prev = temp;
            tail.next = head;
            head.prev = tail;
        }
        size++;
    }
    public void a(GameObject test)
    {
        Debug.Log(test.name);
    }
}

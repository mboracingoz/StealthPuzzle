using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpot : MonoBehaviour
{
    public bool isOccupied { get; private set; } = false;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & LayerMask.GetMask("Player")) != 0)
        {
            isOccupied = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & LayerMask.GetMask("Player")) != 0)
        {
            isOccupied = false;
        }
    }
}

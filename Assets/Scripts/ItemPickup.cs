using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{

    private bool pickUpAllowed;

    private string pTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pTag = collision.gameObject.tag;
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (pTag == "Player1")
        {
            if (!player.IsHoldingItem)
            {
                player.IsHoldingItem = false;

            }
                
        }
        else if (pTag == "Player2")
            print("p2\n");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        //{
        //    pickUpSprite.gameObject.SetActive(false);
        //    pickUpAllowed = false;
        //}
    }

    private void PickUp()
    {
        
    }

}

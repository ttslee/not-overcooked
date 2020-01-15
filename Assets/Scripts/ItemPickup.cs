using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{

    [SerializeField]
    private GameObject player1Sprite;
    [SerializeField]
    private GameObject player2Sprite;

    private bool pickUpAllowed;

    private string tag;
    // Use this for initialization
    private void Start()
    {
        player1Sprite.gameObject.SetActive(false);
        player2Sprite.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tag = collision.gameObject.tag;
        //if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        //{
        //    pickUpSprite.gameObject.SetActive(true);
        //    pickUpAllowed = true;
        //}
        if (tag == "Player1")
            print("p1\n");
        else if (tag == "Player2")
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
        Destroy(gameObject);
    }

}

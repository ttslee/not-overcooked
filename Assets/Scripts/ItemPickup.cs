using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    private int holder = 0;
    private bool dropped = false;
    private string direction;
    private SpriteRenderer image;

    private void Awake()
    {
        image = gameObject.GetComponent<SpriteRenderer>();
    }

    public int Holder
    {
        get
        {
            return holder;
        }

        set
        {
            holder = value;
            image.sortingOrder = 1;
        }
    }
    public void Kill()
    {
        Destroy(gameObject);
    }

    public void Dropped(string dir)
    {
        direction = dir;
        dropped = true;
        image.sortingOrder = 0;
    }
}

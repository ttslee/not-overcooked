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
    public int Holder
    {
        get
        {
            return holder;
        }

        set
        {
            print(value);
            holder = value;
        }
    }

    private void Update()
    {
        switch(direction)
        {
            case "up":
                break;
            case "down":
                break;
            case "right":
                break;
            case "left":
                break;
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public void Drop(string dir)
    {
        Holder = 0;
        direction = dir;
        dropped = true;
    }
}

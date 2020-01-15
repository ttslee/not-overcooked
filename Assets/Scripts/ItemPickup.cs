using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    private int holder = 0;

    public int Holder
    {
        get
        {
            return holder;
        }

        set
        {
            holder = value;
        }
    }
    public void Kill()
    {
        Destroy(gameObject);
    }

}

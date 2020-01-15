using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{

    public void Kill()
    {
        Destroy(gameObject);
    }

}

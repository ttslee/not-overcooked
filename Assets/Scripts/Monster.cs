using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    //Recipe info
    private string currentItem;

    private bool hasRecipe = false;

    public bool HasRecipe
    {
        get
        {
            return hasRecipe;
        }

        set
        {
            hasRecipe = value;
        }
    }

    private List<string> recipe;

    public List<string> Recipe
    {
        get
        {
            return recipe;
        }

        set
        {
            recipe = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision) // Pick up the correct item
    {
        
    }

    public void WakeUp(List<string> r)
    {
        recipe = r;
        HasRecipe = true;
        currentItem = r[0];
    }
}

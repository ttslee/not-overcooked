using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    //Monster info
    private bool mDone = false; // Bool for checking whether the recipe is complete

    //Recipe info
    private int currentItem;
    
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

    private int numItemsLeft = 4;

    public int NumItemsLeft
    {
        get
        {
            return numItemsLeft;
        }

        set
        {
            numItemsLeft = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(HasRecipe)
        {
            if(TimerDone())
            {
                HasRecipe = false;
                mDone = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // Pick up the correct item
    {
        if(collision.gameObject.name == recipe[currentItem])
        {
            NumItemsLeft -= 1;
            currentItem++;
            collision.gameObject.GetComponent<ItemPickup>().Kill();
            setFloatingSprite(recipe[currentItem]);
        }
        else
        {
            Spit(collision);
        }
    }

    public void WakeUp(List<string> r)
    {
        recipe = r;
        HasRecipe = true;
        currentItem = 0;
        GetComponent<Timer>().SetTime(25f, "Monster");
        setFloatingSprite(recipe[currentItem]);
    }

    private void Spit(Collider2D collision)
    {

    }

    public bool TimerDone()
    {
        return GetComponent<Timer>().Done;
    }

    private void setFloatingSprite(string item)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    // Recipes/ItemList
    [System.Serializable]
    public class Recipes
    {
        public string[] recipes;
    }

    public Recipes[] myRecipes;
    
    public Recipes[] MyRecipes
    {
        get
        {
            return myRecipes;
        }

        set
        {
            myRecipes = value;
        }
    }

    private string[] itemList = 
    {
            "dark ore",
            "red ore",
            "dead mouse",
            ""

    };

    // ManagerTimer
    // Start is called before the first frame update
    void Start()
    {
        // Shuffle list of items for this game.
        for (int i = 0; i < itemList.Length; i++)
        {
            string temp = itemList[i];
            int randomIndex = Random.Range(i, itemList.Length);
            itemList[i] = itemList[randomIndex];
            itemList[randomIndex] = temp;
        }
        //print(itemList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

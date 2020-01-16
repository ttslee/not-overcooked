using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    // Recipes/ItemList
    public int numRecipes = 6;
    [System.Serializable]
    public class Recipes
    {
        public List<string> items;
    }

    public List<Recipes> myRecipes;
    
    public List<Recipes> MyRecipes
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

    private static List<string> itemList1 = new List<string> 
    {
            "red ore",
            "burned mouse",
            "ash",
            "burned skull",
    };
    private static List<string> itemList2 = new List<string>
    {
            "dark ore",
            "rotten mouse",
            "withered herb",
            "withered skull",
    };

    // ManagerTimer
    // Start is called before the first frame update
    void Start()
    {
        // Shuffle list of items for this game.

        for(int n = 0; n < 6; ++n)
        {
            List<string> randomList = GenerateRandomList();
            for (int i = 0; i < 4; i++)
            {
                string temp = randomList[i];
                int randomindex = Random.Range(i, 4);
                randomList[i] = randomList[randomindex];
                randomList[randomindex] = temp;
            }
            for (int j = 0; j < 4; j++)
            {
                MyRecipes[n].items.Add(randomList[j]);
            }
        }
    }
    private List<string> GenerateRandomList()
    {
        List<string> randList = new List<string> ();
        for (int i = 0; i < 2; i++)
        {
            int num = Random.Range(0, 4);
            while (randList.Contains(itemList1[num]))
            {
                num = Random.Range(0, 4);
            }
            randList.Add(itemList1[num]);
            num = Random.Range(0, 4);
            while (randList.Contains(itemList2[num]))
            {
                num = Random.Range(0, 4);
            }
            randList.Add(itemList2[num]);
        }
        return randList;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

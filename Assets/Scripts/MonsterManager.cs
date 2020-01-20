using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    // Recipes/ItemList
    private int count = 0;
    
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
    private float rDelay = 5f;

    // Monster Management
    private int nMonsters = 3;
    private static List<string> mList = new List<string>{ "Monster1", "Monster2", "Monster3" };

    private static List<bool> awakeList = new List<bool> { false, false, false };  // List of monsters that currently have a recipe.

    private Queue<string> monsterQueue;
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
        for(int i = 0; i < nMonsters; ++i)
        {
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

   
    public void setAwake(int monster_num, bool set)
    {
        awakeList[monster_num - 1] = set; 
    }

    private void WakeUpMonster(int monster_num)
    {
        setAwake(monster_num, true); // Sets monster(monster_num) to be awake and starts timing it.
        gameObject.transform.Find(mList[monster_num]).GetComponent<Monster>().WakeUp(MyRecipes[count].items);  // Wakes up a monster and sends it a recipe to complete. 
        count++;
    }
}

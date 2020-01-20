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
    private float timer1 = 25f;
    private float timer2 = 25f;
    private float timer3 = 25f;

    // Monster Management
    private int nMonsters = 3;
    private static List<string> mList = new List<string>{ "Monster1", "Monster2", "Monster3" };

    private static List<bool> awakeList = new List<bool> { false, false, false };  // List of monsters that currently have a recipe.
    // Start is called before the first frame update
    void Start()
    {
        // Shuffle list of items for this game.

        for(int n = 0; n < 6; ++n)
        {
            List<string> randomList = GenerateRandomList();
            for (int i = 0; i < nMonsters + 1; i++)
            {
                string temp = randomList[i];
                int randomindex = Random.Range(i, nMonsters + 1);
                randomList[i] = randomList[randomindex];
                randomList[randomindex] = temp;
            }
            for (int j = 0; j < nMonsters + 1; j++)
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
            int num = Random.Range(0, nMonsters + 1);
            while (randList.Contains(itemList1[num]))
            {
                num = Random.Range(0, nMonsters + 1);
            }
            randList.Add(itemList1[num]);
            num = Random.Range(0, nMonsters + 1);
            while (randList.Contains(itemList2[num]))
            {
                num = Random.Range(0, nMonsters + 1);
            }
            randList.Add(itemList2[num]);
        }
        return randList;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (awakeList[0])
            timer1 -= Time.deltaTime;
        if (awakeList[1])
            timer2 -= Time.deltaTime;
        if (awakeList[2])
            timer3 -= Time.deltaTime;
    }
    public void setAwake(int monster_num, bool setAwake)
    {
        awakeList[monster_num - 1] = setAwake; 
    }

    private void WakeUpMonster(int monster_num)
    {
        setAwake(monster_num, true); // Sets monster(monster_num) to be awake and starts timing it.
        gameObject.transform.Find(mList[monster_num]).GetComponent<Monster>().WakeUp(MyRecipes[count].items);  // Wakes up a monster and sends it a recipe to complete. 
        count++;
    }
}

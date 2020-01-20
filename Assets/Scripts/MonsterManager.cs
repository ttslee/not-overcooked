using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    // Recipes/ItemList
    private int nRecipes = 6;
    private int recipeSize = 4;
    private int count = 0;
    private int unfinished_recipes = 0;
    private int completed_recipes = 0;

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
            "burnt rat",
            "burnt eye",
            "burnt skull",
    };
    private static List<string> itemList2 = new List<string>
    {
            "dark ore",
            "rotten rat",
            "rotten eye",
            "rotten skull",
    };

    // ManagerTimer
    private Timer timer;
    private float rDelay = 5f;

    // Monster Management
    private static List<string> mList = new List<string>{ "Monster1", "Monster2", "Monster3" };
    private static List<int>    mAvailableList = new List<int> { 0, 1, 2 };
    //private static List<bool>   awakeList = new List<bool> { false, false, false };  // List of monsters that currently have a recipe.
    // Start is called before the first frame update
    public void Start()
    {
        timer = gameObject.GetComponent<Timer>();
        // Shuffle list of items for this game.
        for(int n = 0; n < nRecipes; ++n)
        {
            List<string> randomList = GenerateRandomList();
            ShuffleList<string>(randomList);
            for (int j = 0; j < recipeSize; j++)
            {
                MyRecipes[n].items.Add(randomList[j]);
            }
        }
        ShuffleList<int>(mAvailableList);
        WakeUpMonster(mAvailableList[0]);
        
    }

    public static void ShuffleList<T>(List<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
    private List<string> GenerateRandomList()
    {
        List<string> randList = new List<string> ();
        for (int i = 0; i < 2; i++)
        {
            int num = Random.Range(0, 3);
            while (randList.Contains(itemList1[num]))
            {
                num = Random.Range(0, 3);
            }
            randList.Add(itemList1[num]);
            num = Random.Range(0, 3);
            while (randList.Contains(itemList2[num]))
            {
                num = Random.Range(0, 3);
            }
            randList.Add(itemList2[num]);
        }
        return randList;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(count == nRecipes && completed_recipes >= 4)
        {
            // Players Win
        }
        else if(unfinished_recipes == nRecipes)
        {
            Application.Quit();
        }
        if(timer.Done)
        {
            if(mAvailableList.Count > 0)
            {
                ShuffleList<int>(mAvailableList);
                WakeUpMonster(mAvailableList[0]);
                timer.SetTime(rDelay, "MonsterManager");
            }
            
        }
    }

    // might be redundant 
    //public void SetAwake(int monster_num, bool set) 
    //{
    //    awakeList[monster_num] = set; 
    //}

    private void WakeUpMonster(int monster_num)
    {
        //SetAwake(monster_num, true); // Sets monster(monster_num) to be awake and starts timing it.
        mAvailableList.Remove(monster_num);
        gameObject.transform.Find(mList[monster_num]).GetComponent<Monster>().WakeUp(MyRecipes[count].items, mList[monster_num], monster_num);  // Wakes up a monster and sends it a recipe to complete. 
        count++;
        timer.SetTime(rDelay, "MonsterManager");
    }

    public void AlertManager_RecipeComplete(int monster_num)
    {
        mAvailableList.Add(monster_num);
        //SetAwake(monster_num, false);
        completed_recipes++;
    }

    public void AlertManager_TimedOut(int monster_num)
    {
        mAvailableList.Add(monster_num);
        unfinished_recipes++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public GameObject itemSpawn;

    [SerializeField]
    private Sprite item1;
    [SerializeField]
    public Sprite item2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collision2D collision)
    {
        switch(collision.gameObject.name)
        { 
            case "Player1":
            case "Player2":
                collision.gameObject.GetComponent<PlayerController>().TakeDamage();
                break;
            case "Fire":
                itemSpawn.GetComponent<SpriteRenderer>().sprite = item1;
                Instantiate(itemSpawn, null);
                break;
            case "Death":
                itemSpawn.GetComponent<SpriteRenderer>().sprite = item2;
                Instantiate(itemSpawn, null);
                break;
        }
    }
}

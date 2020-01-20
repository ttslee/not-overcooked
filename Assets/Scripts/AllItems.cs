using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllItems : MonoBehaviour
{
    [System.Serializable]
    public struct NamedImage
    {
        public string name;
        public Sprite image;
    }
    public NamedImage[] sprites;
    private Dictionary<string, Sprite> spriteDictionary = new Dictionary<string, Sprite>();

    public Dictionary<string, Sprite> SpriteDictionary
    {
        get
        {
            return spriteDictionary;
        }

        set
        {
            SpriteDictionary = value;
        }
    }
    private void Start()
    {
        foreach(var item in sprites)
        {
            spriteDictionary.Add(item.name, item.image);
        }
    }
}

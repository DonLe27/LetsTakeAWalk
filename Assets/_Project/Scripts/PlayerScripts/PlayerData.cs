using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public string player_name = "";
    public Journal journal;
    public Element[] elements;

    //Int array that represents the ingredients of each type that the player currently has
    //Ingredients By Index: (not finalized just an example)
    //0 : Mushrooms,    1 : Fish,   2 : Lettuce, 
    //3 : Potatoes,     4 : Carrots 
    public int[] ingredients = { 0, 0, 0, 0, 0, 0 ,0 };

}
[System.Serializable]

public class Element
{
    public string type;
}
[System.Serializable]

public class Journal
{
    public List<Entry> entries;

}
[System.Serializable]
public class Entry
{
    public string title;
    public string content;
    public Entry(string t, string c = "", string type = "question")
    {
        title = t;
        content = c;
    }
}



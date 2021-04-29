using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public string player_name = "";
    public Journal journal;
    public Element[] elements;

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
    public Entry(string t, string c = "")
    {
        title = t;
        content = c;
    }
}



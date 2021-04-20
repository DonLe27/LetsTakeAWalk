using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public DataManager dm;
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            dm.Load();
        }
        if (Input.GetKeyDown("c"))
        {
            dm.playerData.player_name = "beef";
            dm.Save();

        }
    }
}

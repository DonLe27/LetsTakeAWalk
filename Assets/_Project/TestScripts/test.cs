using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class test : NetworkBehaviour
{
    private ManagePlayerData managePlayerData;
    void Start()
    {
        managePlayerData = GameObject.Find("PlayerDataManager").GetComponent<ManagePlayerData>();
    }
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            managePlayerData.ReceivePrompt(Random.Range(0, 10).ToString());
        }
        if (Input.GetKeyDown("c"))
        {
            managePlayerData.wipeData();
        }

    }
}

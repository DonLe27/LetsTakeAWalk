using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class test : NetworkBehaviour
{
    public ManagePlayerData managePlayerData;

    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            managePlayerData.ReceivePrompt(Random.Range(0, 10).ToString());
        }

    }
}

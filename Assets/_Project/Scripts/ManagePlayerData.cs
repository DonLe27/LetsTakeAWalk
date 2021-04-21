using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Changes during the game will change this playerData object
// On unload it will use the data manager to write out
public class ManagePlayerData : MonoBehaviour
{
    public DataManager dataManager;
    public PlayerData playerData;
    void Start()
    {
        dataManager.Load();
        playerData = dataManager.playerData;
    }

    // Write the data to file
    void OnDestroy()
    {
        dataManager.playerData = playerData;
        dataManager.Save();
    }

}

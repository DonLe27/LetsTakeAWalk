using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSinglePlay : MonoBehaviour
{
    [SerializeField] GameObject networkManagerSinglePlayer;
    [SerializeField] private GameObject connectionUI;
    public void SinglePlayerMode()
    {
        GameObject networkManager = Instantiate(networkManagerSinglePlayer, new Vector3(0, 0, 0), Quaternion.identity);
        networkManager.GetComponent<CustomNetworkManager>().singlePlayerMode = true;
        connectionUI.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class ChooseNetworkHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public bool usingSteamworks = false;
    [SerializeField] GameObject networkManagerDev;
    [SerializeField] GameObject networkManagerProd;

    private void Start()
    {
        if (usingSteamworks)
        {
            Instantiate(networkManagerProd, new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(networkManagerDev, new Vector3(0, 0, 0), Quaternion.identity);

        }

    }
}



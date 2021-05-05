using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class ChooseNetworkHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public bool usingSteamworks = false;

    private void Start()
    {
        if (usingSteamworks)
        {
            Destroy(GetComponent<kcp2k.KcpTransport>());
            Destroy(GetComponent<NetworkManagerHUD>());
            GetComponent<SteamworksManager>().enabled = true;
            GetComponent<Mirror.FizzySteam.FizzySteamworks>().enabled = true;
            transform.Find("ConnectionUI").gameObject.SetActive(true);
        }
        else
        {
            GetComponent<kcp2k.KcpTransport>().enabled = true;
            GetComponent<NetworkManagerHUD>().enabled = true;
            Destroy(GetComponent<SteamworksManager>());
            Destroy(GetComponent<Mirror.FizzySteam.FizzySteamworks>());
            Destroy(transform.Find("ConnectionUI").gameObject);
        }

    }
}



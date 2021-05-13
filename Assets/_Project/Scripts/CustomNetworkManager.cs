using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class CustomNetworkManager : NetworkManager
{
    [SerializeField] private bool usingSteamworks = false;
    public override void Start()
    {

        /* if (usingSteamworks)
         {
             Destroy(GetComponent<kcp2k.KcpTransport>());
             Destroy(GetComponent<NetworkManagerHUD>());
             GetComponent<SteamworksManager>().enabled = true;
             GetComponent<Mirror.FizzySteam.FizzySteamworks>().enabled = true;
             transform.Find("ConnectionUI").gameObject.SetActive(true);
             transport = GetComponent<Mirror.FizzySteam.FizzySteamworks>();
         }
         else
         {
             GetComponent<kcp2k.KcpTransport>().enabled = true;
             GetComponent<NetworkManagerHUD>().enabled = true;
             Destroy(GetComponent<SteamworksManager>());
             Destroy(GetComponent<Mirror.FizzySteam.FizzySteamworks>());
             Destroy(transform.Find("ConnectionUI").gameObject);
         }*/
        base.Start();
    }
    public override void OnStartServer()
    {
        base.OnStartServer();

        // Spawn Canoe
        GameObject canoe = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Canoe"));
        NetworkServer.Spawn(canoe);

        //Spawn ingredient
        GameObject ingredient = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ingredient"));
        ingredient.transform.position = new Vector3(320, 10, 200);
        NetworkServer.Spawn(ingredient);
    }
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        // Add player at spawn position
        Transform startPos = GetStartPosition();
        GameObject player = startPos != null
            ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
            : Instantiate(playerPrefab);

        // instantiating a "Player" prefab gives it the name "Player(clone)"
        // => appending the connectionId is WAY more useful for debugging!
        player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
        NetworkServer.AddPlayerForConnection(conn, player);
    }


    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
    }




}

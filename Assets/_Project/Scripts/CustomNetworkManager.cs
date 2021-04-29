using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class CustomNetworkManager : NetworkManager
{
    public GameObject cameraPrefab;
    // Start is called before the first frame update
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

        // Spawn Canoe
        GameObject canoe = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Canoe"));
        NetworkServer.Spawn(canoe);

    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
    }
}

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
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        Debug.Log(cameraObj);
        // Set camera to follow player and 
        cameraObj.transform.SetPositionAndRotation(player.transform.position, player.transform.rotation);
        cameraObj.transform.SetParent(player.transform);

        cameraObj.AddComponent<CamMouseLook>();
    }
}

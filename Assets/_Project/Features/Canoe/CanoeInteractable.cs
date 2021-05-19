using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CanoeInteractable : NetworkInteractable
{
    [Server]
    public override void RespondToInteraction(GameObject player)
    {
        // Mount the player to the canoe and position them
        player.transform.parent = this.transform; // make this (canoe) the parent of player
        Debug.Log("Mounted");
    }

    // Use NetworkTransform component to sync
    public void Row(GameObject player)
    {
        Debug.Log("row");
        // Code for moving the canoe
        float movementSpeed = 100f;
        transform.position += transform.forward * Time.deltaTime * movementSpeed;

    }

    // Can also use ClientRpc to broadcast changes to clients
    /*
           [ClientRpc]
    private void RpcRespond(GameObject player)
    {
        Vector3 velocity = gameObject.transform.position - player.transform.position;
        GetComponent<Rigidbody>().AddForce(velocity.normalized, ForceMode.Impulse);
    }

    */
}

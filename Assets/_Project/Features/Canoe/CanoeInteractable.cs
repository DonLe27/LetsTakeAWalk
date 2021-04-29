using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CanoeInteractable : NetworkInteractable
{
    [Server]
    public override void RespondToInteraction(GameObject player)
    {
        RpcRespond(player);
    }

    [ClientRpc]
    private void RpcRespond(GameObject player)
    {
        Vector3 velocity = gameObject.transform.position - player.transform.position;
        GetComponent<Rigidbody>().AddForce(velocity.normalized, ForceMode.Impulse);
    }
}

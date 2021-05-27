using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class IngredientInteract: NetworkInteractable
{

    public IngredientID id;
    public GameObject canvas;

    [Server]
    public override void RespondToInteraction(GameObject player)
    {
        Respond(player);
    }

    // Use NetworkTransform component to sync
    private void Respond(GameObject player)
    {
        
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

// public class IngredientInteract : MonoBehaviour
// {
//     void RespondToInteraction()
//     {
//         transform.Translate(Vector3.up * 2, Space.World);
//         Debug.Log("Picked up Ingredient");
//     }
// }


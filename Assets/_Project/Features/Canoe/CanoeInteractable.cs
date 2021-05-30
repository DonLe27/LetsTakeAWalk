using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CanoeInteractable : NetworkBehaviour
{
    [SyncVar]
    public int canoeCount = 0;
    [Server]
    public void RespondToInteraction(int delta)
    {
        canoeCount += delta;
    }


    public int GetCanoeCount()
    {
        return canoeCount;
    }

    // Use NetworkTransform component to sync

    public Rigidbody rb;
    
    public void Row(args arg)
    {
        /*if (isInFront) {
            Debug.Log("im in front");
        }
        else {
            Debug.Log("back");
        }*/
        rb = arg.obj.GetComponent<Rigidbody>();
        Debug.Log(transform.forward);
        Debug.Log("row");
        // Code for moving the canoe
        float movementSpeed = 10f;
        if (arg.inFront) {
            Debug.Log("Front player.");
            // row to the right
        }
        else {
            Debug.Log("Back player");
            // row to the left
        }

        // transform.position += -transform.forward * Time.deltaTime * movementSpeed;
        rb.AddForce(-transform.forward * movementSpeed); // once i figure this out, move them to the if-else with corresponding directions
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

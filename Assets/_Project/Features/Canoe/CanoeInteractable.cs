using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CanoeInteractable : NetworkInteractable
{
    [SerializeField] private Vector3 playerOffset = new Vector3(0, 0, 0);
    [Server]
    public override void RespondToInteraction(GameObject player)
    {
        // Mount the player to the canoe and position them
        bool firstMounted = true;
        foreach (GameObject playerObject in GameObject.FindGameObjectsWithTag("Player"))
        {
            Debug.Log(transform.gameObject.name);
            // Other player was already mounted
            if (playerObject.transform.parent != null)
            {
                Debug.Log("there was a plyaer");
                firstMounted = false;
            }
        }
        if (firstMounted)
        {
            player.transform.parent = this.transform; // make this (canoe) the parent of player
            player.transform.localPosition = playerOffset;
        }
        else
        {
            player.transform.parent = this.transform; // make this (canoe) the parent of player
            player.transform.localPosition = playerOffset - new Vector3(0, 0, 5);
        }

        player.transform.localRotation = Quaternion.Euler(0, 180, 0);
        player.GetComponent<FirstPersonAIO>().enabled = false;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    // Use NetworkTransform component to sync
    public void Row(GameObject player)
    {
        Debug.Log("row");
        // Code for moving the canoe
        float movementSpeed = 100f;
        transform.position += -transform.forward * Time.deltaTime * movementSpeed;

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

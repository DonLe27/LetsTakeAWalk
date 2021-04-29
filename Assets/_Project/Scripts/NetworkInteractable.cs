using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

abstract public class NetworkInteractable : NetworkBehaviour
{
    public abstract void RespondToInteraction(GameObject player);

}

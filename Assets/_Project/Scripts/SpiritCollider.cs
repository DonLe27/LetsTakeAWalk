using UnityEngine;
using UnityEngine.UI;

public class SpiritCollider : MonoBehaviour
{

    public bool isRetriggerable = false;
    bool wasTriggered = false;

    void OnTriggerEnter(Collider collisionInfo)
    {

        if (!wasTriggered) //checks if the block has been triggered
        {

            if (collisionInfo.tag == "Player") //if player collided with trigger
            {
                wasTriggered = true;
                // Fire ReceivePrompt function on player's gameobject
                collisionInfo.SendMessage("ReceivePrompt", "prompt parameter");
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider collisionInfo)
    {

            if (collisionInfo.tag == "Player") //if player collided with trigger
            {
            // Fire ReceivePrompt function on player's gameobject
            Debug.Log("collided with" + gameObject.GetComponent<IngredientInfo>().id);
            collisionInfo.SendMessage("SetToPickUp", gameObject);
            }
    }

    void OnTriggerExit(Collider collisionInfo){
            if (collisionInfo.tag == "Player") //if player collided with trigger
            {
            // Fire ReceivePrompt function on player's gameobject
            Debug.Log("uncollided with" + gameObject.GetComponent<IngredientInfo>().id);
            collisionInfo.SendMessage("ResetToPickUp", gameObject);
            }
    }
}

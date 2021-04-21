using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerQuestion : MonoBehaviour
{
    public Text displayText;
    public bool isRetriggerable = false;
    bool wasTriggered = false;

    void OnTriggerEnter(Collider collisionInfo){
        //Debug.Log("collided");
        if (!wasTriggered) //checks if the block has been triggered
        {
            
            if (collisionInfo.tag == "Player") //if player collided with trigger
            {
                //Debug.Log("Triggered");
                displayText.text = "Who are you?";
                if(!isRetriggerable) // if block is not retriggerable set wasTriggered to false to prevent retriggering
                    wasTriggered = true;
            }
        }
    }

}

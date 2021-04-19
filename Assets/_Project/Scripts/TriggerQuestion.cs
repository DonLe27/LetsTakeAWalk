using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerQuestion : MonoBehaviour
{
    public Text displayText;

    void OnTriggerEnter(Collider collisionInfo){
        Debug.Log("collided");
        if (collisionInfo.tag == "Player")
        {
            displayText.text = "Who are you?";
        }
    }

}

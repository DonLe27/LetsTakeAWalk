using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritBase : MonoBehaviour
{
    private SpiritSpawner spiritSpawner;

    void Start() {
        spiritSpawner = FindObjectOfType<SpiritSpawner>();
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.tag == "Player") {
            collisionInfo.SendMessage("ReceivePrompt", "prompt parameter");
            // TODO: let server know player found spirit!
            spiritSpawner.DespawnSpirit(this.gameObject);
        }
    }
}


using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo) {
        if(collisionInfo.collider.name == "Cactus")
        {
            FindObjectOfType<AudioManager>().Play("Oof");
        }
    }
}

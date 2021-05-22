using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnParticleCollision(GameObject particle)
    {
        Debug.Log("collided");
        particle.GetComponent<ParticleSystemRenderer>().material.color = Color.green;
    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwap : MonoBehaviour
{
    public string newTrack;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().SwapTrack(newTrack);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player"))
        {
            AudioManager.instance.ReturnToDefault();
        }
    }
}

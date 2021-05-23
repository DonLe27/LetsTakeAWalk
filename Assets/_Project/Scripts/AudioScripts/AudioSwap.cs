
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwap : MonoBehaviour
{
    public string newTrack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            audioManager.SwapTrack(newTrack);
            audioManager.inSpecialArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.ReturnToDefault();
            AudioManager.instance.inSpecialArea = false;
        }
    }
}

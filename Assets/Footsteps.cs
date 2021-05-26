using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioClip clip;
    private AudioSource audioSource;
    private GameObject bridgeMiddle;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bridgeMiddle = GameObject.Find("bridge_middle");
    }


    // Step is called everytime a player steps
    private void Step()
    {
       // bridgeMiddle.transform.velocity = new Vector3(1, 3, 0);

        audioSource.PlayOneShot(clip);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSpread : MonoBehaviour
{
    private Renderer rend;
    private Vector3 center = new Vector3(100, 0, 100);
    private float distance = 30;
    private GameObject[] players;
    private bool wasTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        players = GameObject.FindGameObjectsWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject player in players)
        {
            if (!wasTriggered && Vector3.Distance(player.transform.position, center) < distance)
            {
                wasTriggered = true;
                rend.material.SetFloat("_CSStartSpread", 1.0f);
                rend.material.SetFloat("_CSStartTime", Time.time);
            }
        }


    }
}

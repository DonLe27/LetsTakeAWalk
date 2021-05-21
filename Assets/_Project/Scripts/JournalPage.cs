using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalPage : MonoBehaviour
{
    private GameObject player;
    private bool canDisable = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (canDisable && (Input.GetButton("Cancel") || Input.GetMouseButtonDown(0)))
        {
            canDisable = false;
            player.SetActive(true);
            Destroy(gameObject);
        }

    }

    public void RespondToInteraction(GameObject p)
    {
        player = p;
        canDisable = true;
        player.SetActive(false);
    }
}

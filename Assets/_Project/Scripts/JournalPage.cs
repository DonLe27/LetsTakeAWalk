using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalPage : MonoBehaviour
{
    [SerializeField] GameObject pageCamera;
    private GameObject player;
    private bool canDisable = false;
    // Start is called before the first frame update
    void Start()
    {
        pageCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canDisable && (Input.GetButton("Cancel") || Input.GetMouseButtonDown(0)))
        {
            canDisable = false;
            pageCamera.SetActive(false);
            player.SetActive(true);
            Destroy(gameObject);
        }

    }

    public void RespondToInteraction(GameObject p)
    {
        player = p;
        pageCamera.SetActive(true);
        canDisable = true;
        player.SetActive(false);
    }
}

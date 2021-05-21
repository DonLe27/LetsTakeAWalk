using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalPage : MonoBehaviour
{
    private GameObject player;
    private bool canDisable = false;
    [SerializeField]
    private GameObject pageModel;
    [SerializeField]
    private GameObject pageUI;

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
            player.GetComponent<FirstPersonAIO>().ControllerPause();
            Destroy(gameObject);
        }

    }

    public void RespondToInteraction(GameObject p)
    {
        player = p;
        canDisable = true;
        player.GetComponent<FirstPersonAIO>().ControllerPause();
        pageModel.SetActive(false);
        pageUI.SetActive(true);
    }
}

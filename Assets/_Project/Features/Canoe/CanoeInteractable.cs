using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoeInteractable : NetworkInteractable
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void RespondToInteraction(GameObject player)
    {

        Vector3 velocity = gameObject.transform.position - player.transform.position;
        GetComponent<Rigidbody>().AddForce(velocity.normalized, ForceMode.Impulse);
    }
}

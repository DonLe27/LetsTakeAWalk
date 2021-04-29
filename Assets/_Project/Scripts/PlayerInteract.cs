using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PlayerInteract : NetworkBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public LayerMask mask;
    public Vector3 collision;
    public float rayDistance = 10;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (!isLocalPlayer) return;
        if (Input.GetButton("Fire1"))
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance, mask))
            {
                hit.transform.gameObject.SendMessage("RespondToInteraction", gameObject);
            }
        }
    }


}

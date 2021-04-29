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
        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cam = cameraObj.GetComponent<Camera>();
        // Set camera to follow player
        cameraObj.transform.SetPositionAndRotation(gameObject.transform.position, gameObject.transform.rotation);
        cameraObj.transform.SetParent(gameObject.transform);

        // Add CamMouseLook to camera and set player variable
        cameraObj.AddComponent<CamMouseLook>();
        cameraObj.GetComponent<CamMouseLook>().character = gameObject;

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

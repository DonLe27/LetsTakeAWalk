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
    private Transform body;
    public override void OnStartLocalPlayer()

    {
        base.OnStartLocalPlayer();
        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cam = cameraObj.GetComponent<Camera>();
    }

    [Client]
    void Update()
    {
        if (!isLocalPlayer) return;
        if (!Utilities.MouseInsideScreen()) return;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        // Get button for unmounting
        // Unparent the canoe

        /*
        if (player has mounted the canoe){
            if (keyboard for row was pressed){
                // Try other find functions for the name, etc
                // OR you can do gameObject.parent ??
                GameObject canoe = GameObject.FindObjectOfType<CanoeInteractable>(); 
                CmdRow(canoe);
            }   
        }

        */
        if (Input.GetButton("Fire1"))
        {
            //Debug.Log("Fired Ray");
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance, mask))
            {
                GameObject target = hit.transform.gameObject;
                //Debug.Log("hit target:" +target.name);
                CmdInteract(target);
                if (target.tag == "Ingredient")
                {
                    TakeIngredient(target);
                }
            }
        }
    }

    // This function is run by the server's player object
    [Command]
    private void CmdInteract(GameObject target)
    {
        target.SendMessage("RespondToInteraction", gameObject);
    }

    [Command]
    private void CmdRow(GameObject target)
    {
        target.SendMessage("Row", gameObject);
    }

    //Player picks up an ingredient and adds it to inventory
    private void TakeIngredient(GameObject target)
    {
        IngredientID id = target.GetComponent<IngredientInfo>().id;
        //Debug.Log("picked up ingredient of type: " + id);
        ManagePlayerData managePlayerData = gameObject.GetComponent<ManagePlayerData>();
        managePlayerData.updateIngredients(id, true);
    }


}

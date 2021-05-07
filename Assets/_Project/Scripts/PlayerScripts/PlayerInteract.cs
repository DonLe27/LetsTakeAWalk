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
    private int colorSwitch = -1;

    [SyncVar]
    private Color myColor = Color.white;
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
        if (Input.GetKeyDown("c"))
        {
            CmdChangeOwnColor(gameObject, colorSwitch);
            gameObject.GetComponent<Renderer>().material.color = colorSwitch == 1 ? Color.red : Color.white;
            colorSwitch = colorSwitch * -1;
        }
        if (Input.GetButton("Fire1") || Input.GetKeyDown("e"))
        {
            //Debug.Log("Fired Ray");
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance, mask))
            {
                GameObject target = hit.transform.gameObject;
                //Debug.Log("hit target:" +target.name);
                CmdInteract(target);
                /*if (target.tag == "Player")
                {
                    CmdTag(target, gameObject);
                }*/
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

    [Command]
    private void CmdTag(GameObject tagged, GameObject tagger)
    {
        int colorInt = tagged.GetComponent<Renderer>().material.color == Color.red ? -1 : 1;
        //(tagged, colorInt);
    }

    [Command]
    private void CmdChangeOwnColor(GameObject target, int color)
    {
        ChangeColorOnClients(target, color);
    }

    [ClientRpc]
    private void ChangeColorOnClients(GameObject target, int color)
    {
        target.GetComponent<Renderer>().material.color = color == 1 ? Color.red : Color.white;
    }

    private void RespondToInteraction(GameObject target)
    {
        int colorInt = gameObject.GetComponent<Renderer>().material.color == Color.red ? -1 : 1;
        CmdChangeOwnColor(gameObject, colorInt);

    }


}

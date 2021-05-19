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
    private ManagePlayerData managePlayerData;
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cam = cameraObj.GetComponent<Camera>();
        managePlayerData = gameObject.GetComponent<ManagePlayerData>();
    }

    [Client]
    void Update()
    {
        if (!isLocalPlayer) return;
        if (!Utilities.MouseInsideScreen()) return;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        // Get button for unmounting
        // Unparent the canoe
        if (Input.GetKeyDown("space")) // using space to unmount for now
        {
            // GameObject canoe = GameObject.FindObjectOfType<CanoeInteractable>(); 
            // GameObject.FindObjectOfType<CanoeInteractable>().parent = null;
            CanoeInteractable canoe = GameObject.FindObjectOfType<CanoeInteractable>();
            canoe.transform.DetachChildren();
        }

        if (this.transform.parent != null) { // if player has mounted canoe
            if (Input.GetKeyDown("r")) // if keyboard for row was pressed
            {
                CanoeInteractable canoe = GameObject.FindObjectOfType<CanoeInteractable>();
                CmdRow(canoe.transform.gameObject);
            }
        }

        if (Input.GetButton("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayDistance, mask))
            {
                GameObject target = hit.transform.gameObject;
                if (target.GetComponent<NetworkIdentity>())
                {
                    CmdInteract(target);
                }

                if (target.tag == "Ingredient")
                {
                    TakeIngredient(target);
                }
                else if (target.tag == "JournalPage")
                {
                    TakeJournalPage(target);
                }
            }
        }
    }

    // This function is run by the server's player object
    [Command]
    private void CmdInteract(GameObject target)
    {
        target.SendMessage("RespondToInteraction", gameObject, SendMessageOptions.DontRequireReceiver);
    }

    [Command]
    private void CmdRow(GameObject target1)
    {
        target1.SendMessage("Row", this.transform.gameObject);
    }

    //Player picks up an ingredient and adds it to inventory
    private void TakeIngredient(GameObject target)
    {
        IngredientID id = target.GetComponent<IngredientInfo>().id;
        //Debug.Log("picked up ingredient of type: " + id);
        managePlayerData.updateIngredients(id, true);
        Destroy(target);
    }

    private void TakeJournalPage(GameObject target)
    {
        managePlayerData.receiveJournalPage(target);
        target.SendMessage("RespondToInteraction", gameObject);
    }

}

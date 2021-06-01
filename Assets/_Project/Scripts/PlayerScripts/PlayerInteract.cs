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

    private GameObject ingredientToBePickedUp = null; //ingredient to be picked up

    private ManagePlayerData managePlayerData;
    private bool mountedOnCanoe = false;
    [SerializeField] private Vector3 playerCanoeOffset = new Vector3(0, 1, 0);
    [SerializeField] private float canoeRotationY = 0;
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cam = cameraObj.GetComponent<Camera>();
        managePlayerData = GameObject.Find("PlayerDataManager").GetComponent<ManagePlayerData>();
    }

    [Client]
    void Update()
    {
        if (!isLocalPlayer) return;
        if (!Utilities.MouseInsideScreen()) return;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        // Get button for unmounting
        // Unparent the canoe

        if (this.transform.parent != null)
        { // if player has mounted canoe
            if (Input.GetKeyDown("q")) // if keyboard for row was pressed
            {
                CanoeInteractable canoe = GameObject.FindObjectOfType<CanoeInteractable>();
                CmdRowLeft(canoe.transform.gameObject);
            }
            else if (Input.GetKeyDown("e"))
            {
                CanoeInteractable canoe = GameObject.FindObjectOfType<CanoeInteractable>();
                CmdRowRight(canoe.transform.gameObject);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                CanoeInteractable canoe = GameObject.FindObjectOfType<CanoeInteractable>();
                CmdRowForward(canoe.transform.gameObject);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayDistance, mask))
            {

                GameObject target = hit.transform.gameObject;
                if (target.tag == "Ingredient")
                {
                    CmdInteract(target);
                    TakeIngredient(target);
                    destroyIngredient(target);
                }
                else if (target.tag == "CookingPot")
                {
                    Debug.Log("pot: clicked on pot");
                    target.SendMessage("CreateMenu", gameObject); //if click on pot, pot creates cooking menu
                }
                else if (target.tag == "JournalPage")
                {
                    TakeJournalPage(target);
                }
                else if (target.tag == "Canoe")
                {
                    if (!mountedOnCanoe)
                    {
                        MountCanoe(target);
                        CmdCanoeInteract(target, 1);
                        mountedOnCanoe = !mountedOnCanoe;
                    }
                    else
                    {
                        UnmountCanoe(target);
                        CmdCanoeInteract(target, -1);
                        mountedOnCanoe = !mountedOnCanoe;
                    }

                }
                else if (target.tag == "Spirit")
                {
                    target.SendMessage("RespondToInteraction", gameObject);
                }
            }
        }

        //check for pickup
        if (Input.GetKey("p") && ingredientToBePickedUp != null)
        {
            TakeIngredient(ingredientToBePickedUp);
        }
    }

    // This function is run by the server's player object
    [Command]
    private void CmdCanoeInteract(GameObject target, int delta)
    {
        target.SendMessage("RespondToInteraction", delta, SendMessageOptions.DontRequireReceiver);
    }
    [Command]
    private void CmdInteract(GameObject target)
    {
        target.SendMessage("RespondToInteraction", gameObject, SendMessageOptions.DontRequireReceiver);
    }

    [Command]
    private void CmdRowLeft(GameObject target1)
    {
        target1.SendMessage("RowLeft", this.transform.gameObject);
    }
    private void CmdRowRight(GameObject target1)
    {
        target1.SendMessage("RowRight", this.transform.gameObject);
    }
    private void CmdRowForward(GameObject target1)
    {
        target1.SendMessage("RowForward", this.transform.gameObject);
    }

    [Command]
    private void destroyIngredient(GameObject target)
    {
        Destroy(target);
    }

    //Player picks up an ingredient and adds it to inventory
    [Client]
    private void TakeIngredient(GameObject target)
    {
        IngredientID id = target.GetComponent<IngredientInfo>().id;
        //Debug.Log("picked up ingredient of type: " + id);
        managePlayerData.updateIngredients(id, true);
        //Destroy(target);
    }

    //sets item that player collided with to be picked up
    [Client]
    private void SetToPickUp(GameObject target)
    {
        ingredientToBePickedUp = target;
    }

    [Client]
    private void ResetToPickUp(GameObject target)
    {
        if (ingredientToBePickedUp == target)
        {
            ingredientToBePickedUp = null;
        }
    }




    private void TakeJournalPage(GameObject target)
    {
        managePlayerData.receiveJournalPage(target);
        target.SendMessage("RespondToInteraction", gameObject);
    }

    [Client]
    private void MountCanoe(GameObject target)
    {
        if (!isLocalPlayer) return;
        Debug.Log("mounting canoe");
        // Mount the player to the canoe and position them
        transform.parent = target.transform; // make this (canoe) the parent of player
        int canoeCount = target.GetComponent<CanoeInteractable>().GetCanoeCount();
        Debug.Log(canoeCount);
        if (canoeCount == 0)
        {
            Debug.Log("sit in front");
            transform.localPosition = playerCanoeOffset + new Vector3(0, -1.5f, 2.5f);
        }
        else
        {
            Debug.Log("sit behind");
            transform.localPosition = playerCanoeOffset + new Vector3(0, -1.5f, 5);
        }
        Debug.Log(transform.position);
        GetComponent<FirstPersonAIO>().mountCanoe = true;
        transform.rotation = Quaternion.Euler(0, canoeRotationY, 0);
    }

    [Client]
    private void UnmountCanoe(GameObject canoe)
    {
        // GameObject canoe = GameObject.FindObjectOfType<CanoeInteractable>(); 
        // GameObject.FindObjectOfType<CanoeInteractable>().parent = null;
        canoe.transform.DetachChildren();
        GetComponent<FirstPersonAIO>().mountCanoe = false;
    }

}

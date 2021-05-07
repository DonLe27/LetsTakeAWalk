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
    public GameObject txt;
    private int colorSwitch = -1;
    private string team;
    private Color firstColor;
    private bool startGame = false;

    [Client]
    public override void OnStartLocalPlayer()

    {
        team = Random.Range(0, 2) > 0 ? "red" : "white";
        firstColor = Random.Range(0, 2) > 0 ? Color.red : Color.white;
        txt = GameObject.Find("AnnounceText");
        base.OnStartLocalPlayer();
        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cam = cameraObj.GetComponent<Camera>();
        gameObject.GetComponent<Renderer>().material.color = firstColor;
        CmdChangeObjectColor(gameObject, firstColor == Color.red ? 1 : -1);

    }
    [Client]
    private void UpdateAnnounce()
    {
        int white = 0;
        int red = 0;
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (player.GetComponent<Renderer>().material.color == Color.red)
            {
                red += 1;
            }
            else
            {
                white += 1;
            }
            string winner = "";
            if (white == 0 && startGame)
            {
                Debug.Log("red wins");
                winner = "Red wins!";
            }
            if (red == 0 && startGame)
            {
                Debug.Log("white wins");
                winner = "White wins!";
            }
            txt.GetComponent<TMPro.TextMeshProUGUI>().text = "Your team: " + team + "\n" + winner;
        }
    }

    [Client]
    void Update()
    {
        if (!isLocalPlayer) return;
        if (!Utilities.MouseInsideScreen()) return;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        UpdateAnnounce();
        if (Input.GetKeyDown("p"))
        {
            CmdStartGame();
        }
        if (Input.GetKeyDown("c"))
        {
            CmdChangeObjectColor(gameObject, colorSwitch);
            gameObject.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color == Color.white ? Color.red : Color.white;
            colorSwitch = colorSwitch * -1;
        }
        if (Input.GetButton("Fire1") || Input.GetKeyDown("e"))
        {
            //Debug.Log("Fired Ray");
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, rayDistance, mask))
            {
                GameObject target = hit.transform.gameObject;
                if (target.tag == "Player")
                {
                    CmdChangeObjectColor(target, target.GetComponent<Renderer>().material.color == Color.red ? -1 : 1);
                }

            }
        }
    }

    [Command]
    void CmdStartGame()
    {
        Debug.Log("cmd start");
        RpcStartGame();
    }

    [ClientRpc]
    void RpcStartGame()
    {
        Debug.Log("rpc start");
        startGame = true;
    }


    [Command]
    private void CmdChangeObjectColor(GameObject target, int color)
    {
        ChangeColorOnClients(target, color);
    }

    [ClientRpc]
    private void ChangeColorOnClients(GameObject target, int color)
    {
        target.GetComponent<Renderer>().material.color = color == 1 ? Color.red : Color.white;
    }


}

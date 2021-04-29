// Referenced: https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
using UnityEngine;
using Mirror;
public class PlayerMovement : NetworkBehaviour
{


    public Rigidbody rb;
    public float speed = 10.0f;
    private Vector3 playerVelocity;
    public bool freezeRotation = true;
    private void Start()
    {
        if (!isLocalPlayer) return;
        rb.freezeRotation = freezeRotation;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject child = transform.GetChild(0).gameObject; //First child is body
    }
    [Client]
    void Update()
    {
        if (!isLocalPlayer) return;
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }


}
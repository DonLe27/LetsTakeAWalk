// Referenced: https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
using UnityEngine;
using Mirror;
public class PlayerMovement : NetworkBehaviour
{


    private Rigidbody rb;
    public float speed = 10.0f;
    private Vector3 playerVelocity;
    public bool freezeRotation = true;
    private void Start()
    {
        if (!isLocalPlayer) return;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.freezeRotation = freezeRotation;
        Cursor.lockState = CursorLockMode.Locked;

    }
    [Client]
    void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        float forward = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        forward *= Time.deltaTime;
        straffe *= Time.deltaTime;
        rb.AddForce(new Vector3(straffe, 0, forward), ForceMode.VelocityChange);
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }


}
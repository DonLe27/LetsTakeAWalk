// Referenced: https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
using UnityEngine;
using Mirror;
public class PlayerMovement : NetworkBehaviour
{


    public Rigidbody rb;
    public float speed = 10.0f;
    public float jumpPower = 4.0f;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;
    private float distToGround;
    public bool freezeRotation = true;
    private void Start()
    {
        if (!isLocalPlayer) return;
        rb.freezeRotation = freezeRotation;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject child = transform.GetChild(0).gameObject; //First child is body
        distToGround = child.GetComponent<Collider>().bounds.extents.y;
    }

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
    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 1f);
    }
    void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
        rb.AddForce(new Vector3(0, gravityValue, 0), ForceMode.Acceleration);
    }
}
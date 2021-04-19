// Referenced: https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public Rigidbody rb;
    public float speed = 10.0f;
    public float jumpPower = 4.0f;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;
    private float distToGround;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void Update()
    {
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
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
        rb.AddForce(new Vector3(0, gravityValue, 0), ForceMode.Acceleration);
    }
}
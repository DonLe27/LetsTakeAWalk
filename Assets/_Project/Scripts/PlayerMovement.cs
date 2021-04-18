// Referenced: https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public Rigidbody rb;
    public float speed = 10.0f;
    public float jumpPower = 1.0f;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
    void FixedUpdate()
    {
        bool groundedPlayer = transform.position.y == 1;

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {

            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.VelocityChange);
        }
        rb.AddForce(new Vector3(0, gravityValue, 0), ForceMode.Acceleration);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 200f;
    public float sidewaysForce = 500f;

    // Start is called before the first frame update
    void Start()
    {
        //rb.useGravity = false;
        //rb.AddForce(0,200,500);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //add a forward force
        //rb.AddForce(0, 0, forwardForce* Time.deltaTime);
        if (Input.GetKey("d"))//move right
        {
            rb.AddForce(sidewaysForce * Time.deltaTime,0,0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))//move left
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
        }
        if (Input.GetKey("w"))//move forward
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime,ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))//move backward
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime,ForceMode.VelocityChange);
        }
    }
}

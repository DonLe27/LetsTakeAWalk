using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class SpiritMovement : MonoBehaviour
{
    protected Transform origin;
    void Start()
    {
        origin = transform.parent.transform;
    }

    public Rigidbody rb;
    public float speed = 5f;

    void FixedUpdate()
    {
        Move();
    }
    protected abstract void Move();


}


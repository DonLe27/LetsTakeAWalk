using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public float speed; // speedy speedy zoom zoom
    public Vector3 rotationAxis;

    void Update()
    {
        transform.RotateAround(Vector3.zero, rotationAxis, speed * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }
}

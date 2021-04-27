using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    // Note: values need to be changed in both the sun and moon objects individually
    public float rotationSpeed; // speedy speedy zoom zoom
    public Vector3 rotationPoint; // center point for directional lights to point toward
    public Vector3 rotationAxis;  // axis by which the sun/moon rotate

    void Update()
    {
        transform.RotateAround(rotationPoint, rotationAxis, rotationSpeed * Time.deltaTime);
        transform.LookAt(rotationPoint);
    }
}

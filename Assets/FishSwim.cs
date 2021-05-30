using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwim : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 200;
    [SerializeField] Transform origin;
    [SerializeField] float dir = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    protected void Update()
    {
        Vector3 towardsOrigin = new Vector3(origin.position.x - transform.position.x, 0, origin.position.z - transform.position.z);
        Vector3 direction = Vector3.Cross(towardsOrigin, Vector3.up * dir);
        direction.Normalize();

        rb.velocity = direction * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}

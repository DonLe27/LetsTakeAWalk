using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 direction = new Vector3(-1, 0, 1);
    [SerializeField] float speed = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * direction.normalized;
    }
}

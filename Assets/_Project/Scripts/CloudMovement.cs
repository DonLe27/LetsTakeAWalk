using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 direction = new Vector3(-1, 0, 1);
    [SerializeField] float speed = 3f;
    [SerializeField] float boundaryX = -10;
    [SerializeField] float boundaryZ = 2400;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < boundaryX || transform.position.z > boundaryZ)
        {
            Destroy(gameObject);
        }
        transform.position += speed * Time.deltaTime * direction.normalized;
    }
}

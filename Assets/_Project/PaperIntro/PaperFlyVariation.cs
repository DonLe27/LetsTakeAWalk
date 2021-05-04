using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperFlyVariation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 direction;
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position += direction;
    }
}

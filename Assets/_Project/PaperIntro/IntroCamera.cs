using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform paper;
    [SerializeField] Transform start;
    private Vector3 difference;
    void Start()
    {
        gameObject.transform.position = start.position;
        difference = paper.position - start.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = paper.position - difference;

    }
}

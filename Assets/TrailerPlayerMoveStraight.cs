using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerPlayerMoveStraight : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    private bool start = false;
    void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5f);
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!start) return;
        if (speed == 0)
        {
            animator.SetBool("walking", false);
            return;
        }
        animator.SetBool("walking", true);
        Vector3 xz = gameObject.transform.forward * speed;
        rb.velocity = new Vector3(xz.x, rb.velocity.y, xz.z);
    }
}

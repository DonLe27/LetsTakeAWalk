using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperFlyVariation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private float delay;
    private Animator animator;
    private bool start;
    void Start()
    {
        animator = gameObject.GetComponentsInChildren<Animator>()[0];
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool("start", true);

        // Wait for start animation before changing direction
        yield return new WaitForSeconds(1f);
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!start) return;
        transform.position += speed * direction.normalized * Time.deltaTime;
    }
}

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
    private float curLerp = 0;
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
        float curSpeed = Mathf.Lerp(0, speed, curLerp);
        if (curLerp < 1.0f)
        {
            curLerp += 0.5f * Time.deltaTime; // Controls initial acceleration
            curSpeed = Mathf.Lerp(0, speed, curLerp);
        }


        transform.position += curSpeed * direction.normalized * Time.deltaTime;
    }
}

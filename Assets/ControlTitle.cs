using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTitle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float delay = 21;
    [SerializeField] private float secondDelay = 29;
    [SerializeField] private float transition = 4;
    [SerializeField] private float secondTransition = 3;
    private bool start = false;
    private bool secondStart = false;
    void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        start = true;
        yield return new WaitForSeconds(secondDelay);
        secondStart = true;

    }

    void Update()
    {
        if (start)
        {
            StartCoroutine(DoFade(canvasGroup.alpha, 1, transition));
            start = false;
        }
        if (secondStart)
        {
            StopAllCoroutines();
            StartCoroutine(DoFade(canvasGroup.alpha, 0, secondTransition));
            secondStart = false;
        }

    }
    public IEnumerator DoFade(float start, float end, float duration)
    {
        float counter = 0f;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;
        }
    }
}

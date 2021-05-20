using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritQuestionDisplay : MonoBehaviour
{
    [SerializeField] private GameObject questionComponent;
    [SerializeField] private CanvasGroup canvasGroup;
    //[SerializeField] private Vector2 dimensionOffset = new Vector2(1000, 600);
    public TMPro.TextMeshProUGUI textMesh;
    public RectTransform imageRectTransform;
    private Renderer spiritRenderer;
    public bool isFading = false;
    [SerializeField]
    private SpiritSpawner spiritSpawner;


    public void SetImageRectTransform(Vector2 dimensions)
    {
        imageRectTransform.sizeDelta = dimensions; //+ dimensionOffset;
        //Debug.Log(imageRectTransform.sizeDelta);
    }
    public void SetQuestionComponentActive(float duration)
    {
        isFading = true;
        StartCoroutine(DoFade(canvasGroup.alpha, 1, duration));
    }

    public void SetQuestionComponentInactive(float duration, GameObject spirit)
    {
        spiritRenderer = spirit.GetComponent<Renderer>();
        StartCoroutine(DoFade(canvasGroup.alpha, 0, duration, spirit));
    }

    public IEnumerator DoFade(float start, float end, float duration, GameObject spirit = null)
    {
        float counter = 0f;
        while (counter < duration)
        {
            if (spiritRenderer != null && end == 0)
            {
                Color temp = spiritRenderer.material.color;
                temp.a = Mathf.Lerp(start, end, counter / duration);
                spiritRenderer.material.color = temp;
            }
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;
        }
        if (end == 0)
        {
            isFading = false;
            spiritRenderer = null;
            spiritSpawner.DespawnSpirit(spirit);
        }
    }

}

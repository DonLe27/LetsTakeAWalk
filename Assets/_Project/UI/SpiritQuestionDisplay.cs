using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritQuestionDisplay : MonoBehaviour
{
    [SerializeField] private GameObject questionComponent;
    //[SerializeField] private Vector2 dimensionOffset = new Vector2(1000, 600);
    public TMPro.TextMeshProUGUI textMesh;
    public RectTransform imageRectTransform;


    public void SetImageRectTransform(Vector2 dimensions)
    {
        imageRectTransform.sizeDelta = dimensions; //+ dimensionOffset;
        //Debug.Log(imageRectTransform.sizeDelta);
    }
    public void SetQuestionComponentActive(bool val)
    {
        questionComponent.SetActive(val);
    }

}

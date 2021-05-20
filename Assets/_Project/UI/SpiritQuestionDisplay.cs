using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritQuestionDisplay : MonoBehaviour
{
    [SerializeField] private GameObject questionComponent;
    public TMPro.TextMeshProUGUI textMesh;

    public void SetQuestionComponentActive(bool val)
    {
        questionComponent.SetActive(val);
    }

}

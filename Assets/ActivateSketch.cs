using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSketch : MonoBehaviour
{
    private bool hasActivated = false;
    [SerializeField] private GameObject journalUI;
    private ManageJournal manageJournal;
    // Start is called before the first frame update
    void Start()
    {
        manageJournal = journalUI.GetComponent<ManageJournal>();
    }

    void OnTriggerEnter()
    {
        if (!hasActivated)
        {
            Debug.Log("sketch: triggered");
            StartCoroutine(OpenSketch());

            hasActivated = true;
        }
    }



    IEnumerator OpenSketch()
    {
        yield return new WaitForSeconds(8);
        manageJournal.TurnSketchToPainting();
    }
}

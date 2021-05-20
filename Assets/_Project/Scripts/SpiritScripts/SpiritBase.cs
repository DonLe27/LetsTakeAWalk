using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritBase : MonoBehaviour
{
    private SpiritSpawner spiritSpawner;
    private DayCycleController dayCycleController;
    private SpiritQuestionDisplay spiritQuestionDisplay;


    void Start()
    {
        spiritQuestionDisplay = GameObject.Find("SpiritUI").GetComponent<SpiritQuestionDisplay>();
        spiritSpawner = FindObjectOfType<SpiritSpawner>();
        dayCycleController = GameObject.Find("DayManager").GetComponent<DayCycleController>();

    }

    public virtual List<string> GetEasyQuestions()
    {
        return new List<string>(){
            "What is your favorite food?",
            "What are some of your simple pleasures?"
        };
    }

    public virtual List<string> GetHardQuestions()
    {
        return new List<string>(){
            "If you could only eat one food for the rest of your life, what would it be?",
            "If you could redo on day in your life, which day would you choose?"
        };
    }

    public void RespondToInteraction(GameObject player)
    {
        // Can only interact with on spirit at a time
        if (spiritQuestionDisplay.isFading)
        {
            return;
        }
        if (dayCycleController.GetTimeOfDay() < 12f)
        {
            List<string> easyQuestions = GetEasyQuestions();
            int i = Random.Range(0, easyQuestions.Count);
            player.SendMessage("ReceivePrompt", easyQuestions[i]);
            spiritQuestionDisplay.textMesh.text = easyQuestions[i];
        }
        else
        {
            List<string> hardQuestions = GetHardQuestions();
            int i = Random.Range(0, hardQuestions.Count);
            player.SendMessage("ReceivePrompt", hardQuestions[i]);
            spiritQuestionDisplay.textMesh.text = hardQuestions[i];
        }
        // TODO: Change based off text size
        //spiritQuestionDisplay.SetImageRectTransform(spiritQuestionDisplay.textMesh.GetRenderedValues(true));
        spiritQuestionDisplay.SetQuestionComponentActive(2f);
        // TODO: let server know player found spirit!

        StartCoroutine(RemoveSpiritAndUIAfterTime());


    }

    IEnumerator RemoveSpiritAndUIAfterTime()
    {
        yield return new WaitForSeconds(5f);
        spiritQuestionDisplay.SetQuestionComponentInactive(2f, gameObject);
    }
}

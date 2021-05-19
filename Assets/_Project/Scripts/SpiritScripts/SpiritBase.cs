using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritBase : MonoBehaviour
{
    private SpiritSpawner spiritSpawner;
    private DayCycleController dayCycleController;

    void Start()
    {
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

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.tag == "Player")
        {
            if (dayCycleController.GetTimeOfDay() < 12f)
            {
                int i = Random.Range(0, GetEasyQuestions().Count);
                collisionInfo.SendMessage("ReceivePrompt", GetEasyQuestions()[i]);
            }
            else
            {
                int i = Random.Range(0, GetHardQuestions().Count);
                collisionInfo.SendMessage("ReceivePrompt", GetHardQuestions()[i]);
            }

            // TODO: let server know player found spirit!
            spiritSpawner.DespawnSpirit(this.gameObject);
        }
    }
}

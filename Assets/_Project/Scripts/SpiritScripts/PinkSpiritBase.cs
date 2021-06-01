using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Love based questions?
public class PinkSpiritBase : SpiritBase
{
    public override List<string> GetEasyQuestions()
    {
        return new List<string>(){
            "What is your top love language?",
        };
    }
    public override List<string> GetHardQuestions()
    {
        return new List<string>(){
            "Have you ever had your heart broken?"
        };
    }
}

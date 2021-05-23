using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeSpiritBase : SpiritBase
{
    public override List<string> GetEasyQuestions()
    {
        return new List<string>(){
            "What hobby do you spend the most time one?",
            "What are some skills you wish you had?"
        };
    }
    public override List<string> GetHardQuestions()
    {
        return new List<string>(){
            "If money wasn't relevant, what would you do for the rest of your life?"
        };
    }
}

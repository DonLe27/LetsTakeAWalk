using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Questions about family?
public class GreenSpiritBase : SpiritBase
{
    public override List<string> GetEasyQuestions()
    {
        return new List<string>(){
            "Who are you closest to in your family?",
            "What are some family traditions you want to keep alive?"

        };
    }
    public override List<string> GetHardQuestions()
    {
        return new List<string>()
        {
            "What are some ways you want to be like your parents? What would you want to avoid?"
        };
    }
}

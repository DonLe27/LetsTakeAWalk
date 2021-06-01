using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Questions about happiness ?
public class YellowSpiritBase : SpiritBase
{
    public override List<string> GetEasyQuestions()
    {
        return new List<string>(){
            "How have your wishes changed since you were young?"

        };
    }
    public override List<string> GetHardQuestions()
    {
        return new List<string>(){
           "What is one of your fondest childhood memories? The saddest?",
        };
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Questions about happiness ?
public class YellowSpiritBase : SpiritBase
{
    public override List<string> GetEasyQuestions()
    {
        return new List<string>(){
            "What is one of your fondest childhood memories?"

        };
    }
    public override List<string> GetHardQuestions()
    {
        return new List<string>(){
            "What is a memory you wish you could relive?",
        };
    }
}

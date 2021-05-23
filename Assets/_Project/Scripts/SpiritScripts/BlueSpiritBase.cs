using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Dreams ?
public class BlueSpiritBase : SpiritBase
{
    public override List<string> GetEasyQuestions()
    {
        return new List<string>(){
            "Do you every daydream?"
        };
    }
    public override List<string> GetHardQuestions()
    {
        return new List<string>(){
            "What's a dream you have that you may never achieve?"
        };
    }
}

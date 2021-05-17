using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpiritBase : SpiritBase
{
    public override List<string> GetEasyQuestions()
    {
        return new List<string>(){
            "Who are you closest to in your family?",
            "What are some family traditions you want to continue?"
        };
    }
    public override List<string> GetHardQuestions()
    {
        return new List<string>(){
            "What is something you wish your parents understood better?"
        };
    }
}

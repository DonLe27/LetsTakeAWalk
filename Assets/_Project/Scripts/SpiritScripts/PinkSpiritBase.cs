using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Love based questions?
public class PinkSpiritBase : SpiritBase
{
    public override List<string> GetEasyQuestions()
    {
        return new List<string>(){
            "What are your love languages?",
            "What is your ideal date night?",

        };
    }
    public override List<string> GetHardQuestions()
    {
        return new List<string>(){
            "I know I'm in love when _____________.",
            "What's the best lesson an ex has ever taught you?"
        };
    }
}

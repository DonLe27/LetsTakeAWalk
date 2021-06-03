using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Questions about family?
public class GreenSpiritBase : SpiritBase
{
    public override List<string> GetEasyQuestions()
    {
        return new List<string>(){
            "What is a music track or a scene from a film that made you tear up?"

        };
    }
    public override List<string> GetHardQuestions()
    {
        return new List<string>()
        {
            "What event from the past do you most want to see a recording of?"
        };
    }
}

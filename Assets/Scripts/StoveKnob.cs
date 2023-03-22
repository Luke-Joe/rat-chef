using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveKnob : MonoBehaviour
{
    public Stove stoveTop;

    public void KnobToggle()
    {
        if (stoveTop.power == 0)
        {
            stoveTop.power = 1;
        }
        else
        {
            stoveTop.power = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveKnob : MonoBehaviour
{
    public Stove stoveTop;
    public SFXPlaying source;

    void Start() {
        source = GameObject.FindGameObjectsWithTag("AudioManager")[0].GetComponent<SFXPlaying>();
    }
    public void KnobToggle()
    {
        if (stoveTop.power == 0)
        {
            stoveTop.power = 1;
            source.PlayStoveOn();
        }
        else
        {
            stoveTop.power = 0;
        }
    }
}

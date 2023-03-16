using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Random;


public class SFXPlaying : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource ReallyTricky;
    public AudioSource IveGottaPractice;
    public AudioSource HopeWakeUp;
    public AudioSource NeverMadeThis;
    public AudioSource WhatWasThat;

    public AudioSource WeirdDream;

    // public void Start() {

    // }


    public void PlayBad() {
        System.Random rnd = new System.Random();
        int rand = rnd.Next(1, 6);
        if(rand == 1) {
            ReallyTricky.Play();
        } else if (rand == 2) {
             IveGottaPractice.Play();
        } else if (rand == 3) {
            HopeWakeUp.Play();
        } else if (rand == 4) {
            NeverMadeThis.Play();
        } else {
            WhatWasThat.Play();
        }
        // ReallyTricky.Play();
    }

    public void PlayPractice() {
        IveGottaPractice.Play();
    }

    public void PlayWakeUp() {
        HopeWakeUp.Play();
        Debug.Log("Here");
    }

}

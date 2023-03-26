using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Random;


public class MenuSFX : MonoBehaviour
{

    public AudioSource pf1;
    public AudioSource pf2;

    public void Start() {

    }


    public void PlayPF1() {
        pf1.Play();
    }

    public void PlayPF2() {
        pf2.Play();
    }

}
    
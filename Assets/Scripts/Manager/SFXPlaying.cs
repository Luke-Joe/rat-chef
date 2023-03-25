using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Random;


public class SFXPlaying : MonoBehaviour
{
    // bad
    public AudioSource ReallyTricky;
    public AudioSource IveGottaPractice;
    public AudioSource HopeWakeUp;
    public AudioSource NeverMadeThis;
    public AudioSource WhatWasThat;

    // good
    public AudioSource GrandmaUsedToMake;
    public AudioSource PerfectNightSleep;
    public AudioSource RecipeEasy;
    public AudioSource RecipeEasy2;
    public AudioSource TimeToMake;

    // neutral
    public AudioSource n1;
    public AudioSource n2;
    public AudioSource n3;
    public AudioSource n4;
    public AudioSource n5;
    public AudioSource n6;
    public AudioSource n7;
    public AudioSource n8;
    public AudioSource n9;
    public AudioSource n10;
    public AudioSource n11;
    public AudioSource n12;
    public AudioSource WeirdDream;
    public AudioSource kitchenDark;

    //kitchen
    public AudioSource cutting;
    public AudioSource animal;
    public AudioSource Door;
    public AudioSource stoveOn;
    public AudioSource finishedCooking;
    public AudioSource water;




    public void Start() {
        n1.PlayDelayed(3.0f);
        n2.PlayDelayed(9.0f);
        n3.PlayDelayed(13.0f);
        n4.PlayDelayed(18.0f);
        n5.PlayDelayed(23.0f);
        n6.PlayDelayed(28.0f);
        n7.PlayDelayed(33.0f);
        n8.PlayDelayed(38.0f);
        n9.PlayDelayed(43.0f);
        n10.PlayDelayed(48.0f);
        n11.PlayDelayed(53.0f);
        n12.PlayDelayed(68.0f);

        WeirdDream.PlayDelayed(78.0f);
        kitchenDark.PlayDelayed(130.0f);

        n1.PlayDelayed(138.0f);
        n2.PlayDelayed(144.0f);

        n3.PlayDelayed(160.0f);
        n4.PlayDelayed(166.0f);

        kitchenDark.PlayDelayed(200.0f);


        n6.PlayDelayed(250.0f);
        n7.PlayDelayed(256.0f);
        n8.PlayDelayed(262.0f);
        n9.PlayDelayed(270.0f);

        WeirdDream.PlayDelayed(300.0f);

        // n1.PlayDelayed(356.0f);
        // n2.PlayDelayed(362.0f);

        kitchenDark.PlayDelayed(400.0f);

        n3.PlayDelayed(406.0f);
        n4.PlayDelayed(412.0f);

        n6.PlayDelayed(420.0f);
        n7.PlayDelayed(426.0f);
        n8.PlayDelayed(432.0f);
        n9.PlayDelayed(438.0f);

        WeirdDream.PlayDelayed(460.0f);

    }

    public void PlayBad() {
        System.Random rnd = new System.Random();
        int rand = rnd.Next(1, 6);
        Debug.Log(rand);
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
    }

    public void PlayGood() {
        System.Random rnd = new System.Random();
        int rand = rnd.Next(1, 6);
        Debug.Log(rand);
        if(rand == 1) {
            GrandmaUsedToMake.Play();
        } else if (rand == 2) {
             PerfectNightSleep.Play();
        } else if (rand == 3) {
            RecipeEasy.Play();
        } else if (rand == 4) {
            RecipeEasy2.Play();
        } else {
            TimeToMake.Play();
        }
        

    }

    public void PlayCutting() {
        Debug.Log("play cutting");
        cutting.Play();
    }

     public void PlayAnimal() {
        animal.Play();
    }

     public void PlayStoveOn() {
        stoveOn.Play();
    }

     public void PlayDoor() {
        Door.Play();
    }

     public void PlayFinishedCooking() {
        finishedCooking.Play();
    }

    public void PlayWater() {
        water.Play();
    }

}

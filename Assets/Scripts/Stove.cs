using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    public int power;
    private Rigidbody rb;
    public Material Red;
    public Material stoveMaterial;
    public GameObject s;

    // Start is called before the first frame update
    void Start()
    {
        s = GameObject.Find("StoveTops");
        power = 0;
        // changeStoveColour();
    }

    void OnMouseDown() {
        Debug.Log("clicked knob");
        if (power == 0) {
            power = 1;
            changeStoveColour();
        } else {
            power = 0;
            changeStoveColour();
        }
    }

    void changeStoveColour() {

        if (power == 1) {
            s.GetComponent<Renderer>().material = Red;
        } else {
            // GetComponent<Renderer>().material = stoveMaterial;
            s.GetComponent<Renderer>().material = stoveMaterial;

        }
    }

    //TODO: Method that turns on the stove -> sets heat (?)
    //TODO: Temperature slider
    //TODO: adjust cooking time depending on temperature
    //TODO: create child object that allows stove to be tagged as both environment and stove
}

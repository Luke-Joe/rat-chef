using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    public int power;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        power = 1;
        rb = this.GetComponent<Rigidbody>();
        rb.sleepThreshold = 0.0f;
    }
    
    //TODO: Method that turns on the stove -> sets heat (?)
    //TODO: Temperature slider
    //TODO: adjust cooking time depending on temperature
    //TODO: create child object that allows stove to be tagged as both environment and stove
}

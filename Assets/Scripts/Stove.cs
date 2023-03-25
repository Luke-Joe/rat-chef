using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    public int power;
    private Rigidbody rb;
    public Material Red;
    private Material stoveMaterial;

    public IngredientHandler i;

    // Start is called before the first frame update
    void Start()
    {
        power = 0;
        stoveMaterial = this.gameObject.GetComponent<Renderer>().material;
    }

    void Update()
    {
        changeStoveColour();
    }

    void changeStoveColour()
    {

        if (power == 1)
        {
            this.GetComponent<Renderer>().material = Red;
        }
        else
        {
            this.GetComponent<Renderer>().material = stoveMaterial;

        }
    }

    //TODO: Method that turns on the stove -> sets heat (?)
    //TODO: Temperature slider
    //TODO: adjust cooking time depending on temperature
    //TODO: create child object that allows stove to be tagged as both environment and stove
}

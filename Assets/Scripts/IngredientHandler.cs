using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientHandler : MonoBehaviour
{
    public Ingredient ingredient;
    private Rigidbody rb;

    public string ingredientName;
    public bool isCore;
    public int quantity;
    public status state;
    public int value;
    public float cookTime;
    public float burnTime;
    public float currCook;
    public float currBurn;

    // Start is called before the first frame update
    void Start()
    {
        this.ingredientName = ingredient.ingredientName;
        this.isCore = ingredient.isCore;
        this.quantity = ingredient.quantity;
        this.state = ingredient.state;
        this.value = ingredient.value;
        this.cookTime = ingredient.cookTime;
        this.burnTime = ingredient.burnTime;
        this.currCook = 0;
        this.currBurn = 0;
        rb = this.GetComponent<Rigidbody>();
        rb.sleepThreshold = 0.0f;
    }

    void Update()
    {
        //TODO: Check when ingredient switches state and call statushandler
    }

    void StatusHandler()
    {
        switch (this.state)
        {
            case status.raw:
                break;
            case status.cooked:
                break;
            case status.burnt:
                BurnObject();
                break;
            case status.dirty:
                break;
        }
    }

    void BurnObject()
    {
        if (this.state == status.burnt)
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        }
    }
}

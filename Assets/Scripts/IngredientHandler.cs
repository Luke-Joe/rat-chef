using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientHandler : MonoBehaviour
{
    public Ingredient ingredient;
    private Rigidbody rb;
    public SFXPlaying source;


    public string ingredientName;
    public int quantity;
    public status state;
    public int value;
    public float cookTime;
    public float burnTime;
    public float currCook;
    public float currBurn;
    public Dictionary<string, Seasoning> seasonings;
    private status previousState;

    // Constructor that takes in an ingredient
    public IngredientHandler(Ingredient ingredient)
    {
        this.ingredient = ingredient;
        Start();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.ingredientName = ingredient.ingredientName;
        this.quantity = ingredient.quantity;
        this.state = ingredient.state;
        this.value = ingredient.value;
        this.cookTime = ingredient.cookTime;
        this.burnTime = ingredient.burnTime;
        this.currCook = 0;
        this.currBurn = 0;
        this.seasonings = new Dictionary<string, Seasoning>();
        rb = this.GetComponent<Rigidbody>();
        rb.sleepThreshold = 0.0f;
    }

    void Update()
    {
        StatusHandler();
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
                DirtyObject();
                break;
        }
    }

    void BurnObject()
    {
        if (this.state == status.burnt)
        {
            Debug.Log("here");

            this.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
            // s.PlayA();
        }
    }

    //Sets status of handler to dirty and makes appropriate visual changes
    public void DirtyObject()
    {
        if (this.state != status.dirty)
        {
            this.previousState = this.state;
        }

        this.GetComponent<MeshRenderer>().material.color = Color.gray;
        this.state = status.dirty;
        // source.PlayBad();
    }

    public void CleanObject()
    {
        this.state = this.previousState;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Floor")
        {
            DirtyObject();
        }
    }
}

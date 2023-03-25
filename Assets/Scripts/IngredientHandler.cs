using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

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
    public bool prevCooked;
    private Color dirtyColor;
    private Color burnColor;
    private Color colorStatus;

    private bool transferCompleted;

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
        this.value = ingredient.value;
        this.cookTime = ingredient.cookTime;
        this.burnTime = ingredient.burnTime;
        rb = this.GetComponent<Rigidbody>();
        rb.sleepThreshold = 0.0f;
        dirtyColor = Color.green;
        burnColor = Color.black;

        if (!transferCompleted)
        {
            this.state = ingredient.state;
            this.prevCooked = false;
            this.currCook = 0;
            this.currBurn = 0;
            this.seasonings = new Dictionary<string, Seasoning>();
        }
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
                float colorIncrement = Mathf.Min(1 - ((currCook / cookTime) / 2), 1 - (currBurn / burnTime));
                colorStatus = new Color(colorIncrement, colorIncrement, colorIncrement, 1.0f);
                this.GetComponent<MeshRenderer>().material.color = colorStatus;
                break;
            case status.cooked:
                CookIndicator();
                colorIncrement = Mathf.Min(1 - ((currCook / cookTime) / 2), 1 - (currBurn / burnTime));
                colorStatus = new Color(colorIncrement, colorIncrement, colorIncrement, 1.0f);
                this.GetComponent<MeshRenderer>().material.color = colorStatus;
                break;
            case status.burnt:
                this.GetComponent<MeshRenderer>().material.color = burnColor;
                break;
            case status.dirty:
                // Very bad code -> Color increment is actually the increment here instead of the value to be inputted like above
                colorIncrement = Mathf.Max(((currCook / cookTime) / 2), (currBurn / burnTime));

                this.GetComponent<MeshRenderer>().material.color = dirtyColor - new Color(colorIncrement, colorIncrement, colorIncrement, 1.0f);
                break;
        }

        if (this.state != status.dirty)
        {
            this.previousState = this.state;
        }
    }

    //Sets status of handler to dirty and makes appropriate visual changes
    public void DirtyObject()
    {
        if (this.state == status.burnt)
        {
            return;
        }

        this.state = status.dirty;
        source.PlayBad();

    }

    private void CookIndicator()
    {
        if (this.state == status.cooked && !this.prevCooked)
        {
            Debug.Log("cooked");
            // cookedEffect.transform.position = this.transform.position;
            this.GetComponent<VisualEffect>().Play();
            source.PlayFinishedCooking();
            source.PlayGood();

            this.prevCooked = true;
        }
    }

    public void TransferCook(bool prevCooked, float currCook, float currBurn, status state, Dictionary<string, Seasoning> seasonings)
    {
        this.prevCooked = prevCooked;
        this.state = state;
        this.currBurn = currBurn;
        this.currCook = currCook;
        this.seasonings = seasonings;
        transferCompleted = true;
    }

    public void CleanObject()
    {
        this.state = this.previousState;
        Debug.Log("cleaning");
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Floor")
        {
            DirtyObject();
        }
    }
}

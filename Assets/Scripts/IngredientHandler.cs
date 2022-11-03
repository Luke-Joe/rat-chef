using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientHandler : MonoBehaviour
{
    public Ingredient ingredient;

    public string ingredientName;
    public bool isCore;
    public int quantity;
    public int status;
    public int value;

    // Start is called before the first frame update
    void Start()
    {
        this.ingredientName = ingredient.ingredientName;
        this.isCore = ingredient.isCore;
        this.quantity = ingredient.quantity;
        this.status = ingredient.status;
        this.value = ingredient.value;
    }
}

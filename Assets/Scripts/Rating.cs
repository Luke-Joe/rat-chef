using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rating : MonoBehaviour
{
    [SerializeField]
    private Recipe recipe;
    public Dictionary<string, Ingredient> original;
    public Ingredient[] prepared;
    public List<Ingredient> extraneous;

    void Start()
    {
        original = recipe.Ingredients;
    }

    // Initialize an area that counts the ingredients prepared by the player
    // For every ingredient in this area, give it a score base on ingredient quality, status, and value

    // Return a value between 0 and 1 indicating the players score based on ingredient usage
    // The score is based on whether or not the ingredient is prepared, its value (cleanliness), and how much is present
    public float RateIngredients()
    {
        float sum = 0;

        // for (int i = 0; i < prepared.Length; i++)
        // {
        //     if (original.ContainsKey(prepared[i].name))
        //     {
        //         sum +=
        //     }
        //     else
        //     {
        //         extraneous.Add(prepared[i]);
        //     }
        // }

        return sum;
    }
}

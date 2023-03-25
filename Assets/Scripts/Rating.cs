using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rating : MonoBehaviour
{
    [SerializeField]
    private Recipe recipe;
    public List<Ingredient> original;
    public List<GameObject> prepared;
    private List<IngredientHandler> preparedIngredients;

    private List<IngredientHandler> wrongState;
    private List<IngredientHandler> extraIngredients;

    public bool notFood;
    public bool isSeasoned;

    private float maxScore;
    private float currScore;

    void Start()
    {
        original = recipe.ingredients;

        wrongState = new List<IngredientHandler>();
        extraIngredients = new List<IngredientHandler>();

    }

    // Initialize an area that counts the ingredients prepared by the player
    // For every ingredient in this area, give it a score base on ingredient quality, status, and value

    // Return a value between 0 and 1 indicating the players score based on ingredient usage
    // The score is based on whether or not the ingredient is prepared, its value (cleanliness), and how much is present

    // Algorithm is O(n^2) but should be okay considering small size of both arrays. 
    // This is done because dictionaries cant be handled by unity editor scriptable objects. 
    public float RateIngredients()
    {
        maxScore = original.Count + 2;
        currScore = 0;


        for (int i = 0; i < prepared.Count; i++)
        {
            IngredientHandler ih = prepared[i].GetComponent<IngredientHandler>();

            if (ih != null)
            {

                bool inOriginal = false;

                for (int j = 0; j < original.Count; j++)
                {
                    Ingredient orgI = original[0];
                    if (orgI.ingredientName == ih.ingredientName)
                    {
                        inOriginal = true;
                        currScore += 0.5f;
                        // +0.5 if state is correct
                        // +0.5 if correct item
                        // - 0.3 * how burnt food is

                        if (orgI.state == ih.state)
                        {
                            currScore += 0.5f;
                        }
                        else
                        {
                            wrongState.Add(ih);
                        }

                        currScore -= 0.3f * (ih.currBurn / ih.burnTime);

                        //NEED TO HANDLE SEASONINGS
                    }
                }

                if (!inOriginal)
                {
                    // Found a random ingredient
                    extraIngredients.Add(ih);
                    currScore -= 0.5f;
                }
            }
            else
            {
                // IF NOT PLATE
                notFood = true;
                currScore -= 0.5f;
            }
        }

        return currScore / maxScore;
    }

    void OnTriggerEnter(Collider other)
    {
        prepared.Add(other.gameObject);
        RateIngredients();
    }
}

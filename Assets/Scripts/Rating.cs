using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rating : MonoBehaviour
{
    [SerializeField]
    private Recipe recipe;
    public List<GameObject> original;
    public List<GameObject> prepared;
    private List<IngredientHandler> preparedIngredients;

    public bool notFood;
    public bool isSeasoned;

    public float maxScore;
    private float currScore;

    void Start()
    {
        foreach (var obj in recipe.ingredients)
        {
            original.Add(obj);
        }

    }

    // Initialize an area that counts the ingredients prepared by the player
    // For every ingredient in this area, give it a score base on ingredient quality, status, and value

    // Return a value between 0 and 1 indicating the players score based on ingredient usage
    // The score is based on whether or not the ingredient is prepared, its value (cleanliness), and how much is present
    public float RateIngredients()
    {
        maxScore = original.Count;
        currScore = 0;

        // Algorithm is O(n^2) but should be okay considering small size of both arrays. 
        // This is done because dictionaries cant be handled by unity editor scriptable objects. 
        for (int i = 0; i < prepared.Count; i++)
        {
            IngredientHandler ih = prepared[i].GetComponent<IngredientHandler>();
            if (ih != null)
            {
                for (int j = 0; j < original.Count; j++)
                {
                    IngredientHandler orgIH = original[j].GetComponent<IngredientHandler>();
                    Debug.Log(orgIH.ingredientName);
                    Debug.Log(ih.ingredientName);
                    if (orgIH.ingredientName == ih.ingredientName)
                    {
                        Debug.Log("FOUND");
                    }
                    else
                    {
                        Debug.Log("SUSSY");

                    }
                }
            }
            else
            {
                // IF NOT PLATE
                notFood = true;
            }
        }

        return currScore / maxScore;
    }

    void OnTriggerEnter(Collider other)
    {
        // if (other.GetComponent<IngredientHandler>() != null)
        // {
        //     prepared.Add(other.GetComponent<IngredientHandler>());
        // }

        prepared.Add(other.gameObject);
        RateIngredients();
    }
}

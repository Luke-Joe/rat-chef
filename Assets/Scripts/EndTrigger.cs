using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    List<IngredientHandler> finalIngredients = new List<IngredientHandler>();

    void OnTriggerEnter(Collider other)
    {
        IngredientHandler ingredient = other.GetComponent<IngredientHandler>();
        if (ingredient != null && !finalIngredients.Contains(ingredient))
        {
            finalIngredients.Add(ingredient);
        }

        foreach (IngredientHandler ingr in finalIngredients)
        {
            Debug.Log(ingr);
        }

    }

    void OnTriggerExit(Collider other)
    {
        IngredientHandler ingredient = other.GetComponent<IngredientHandler>();
        if (ingredient != null && finalIngredients.Contains(ingredient))
        {
            finalIngredients.Remove(ingredient);
        }
    }
}

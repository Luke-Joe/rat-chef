using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IngredientHandler>() != null)
        {
            IngredientHandler ih = other.GetComponent<IngredientHandler>();

            ih.CleanObject();
        }
    }
}

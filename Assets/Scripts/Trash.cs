using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private BoxCollider zone;

    void Start()
    {
        zone = this.GetComponent<BoxCollider>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<IngredientHandler>() != null)
        {
            IngredientHandler ih = other.GetComponent<IngredientHandler>();

            ih.DirtyObject();

            ih.despawnTime -= Time.deltaTime;

            if (ih.despawnTime <= 0)
            {
                Destroy(other);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        other.GetComponent<IngredientHandler>().despawnTime = other.GetComponent<IngredientHandler>().originalDespawn;
    }
}

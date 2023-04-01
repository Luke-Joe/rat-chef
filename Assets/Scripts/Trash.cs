using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Trash : MonoBehaviour
{
    private BoxCollider zone;
    private float ratDespawn;

    void Start()
    {
        zone = this.GetComponent<BoxCollider>();
        ratDespawn = 10f;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RatController>() != null)
        {
            other.GetComponent<NavMeshAgent>().enabled = false;
            other.GetComponent<RatController>().enabled = false;
            StartCoroutine(RatDespawn(other.gameObject));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IngredientHandler>() != null)
        {
            other.GetComponent<IngredientHandler>().despawnTime = other.GetComponent<IngredientHandler>().originalDespawn;
        }
    }

    private IEnumerator RatDespawn(GameObject rat)
    {
        yield return new WaitForSeconds(ratDespawn);
        Destroy(rat);
    }
}

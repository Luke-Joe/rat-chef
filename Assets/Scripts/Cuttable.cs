using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuttable : MonoBehaviour
{
    public GameObject childIngredient;
    public int num;

    public void Split()
    {
        Vector3 right = transform.right;

        for (int i = 0; i < num; i++)
        {
            float offset = i * 0.01f;
            Vector3 spawnPosition = transform.position + right * offset;
            GameObject child = Instantiate(childIngredient, spawnPosition, transform.rotation);
        }

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuttable : MonoBehaviour
{
    public GameObject childIngredient;
    private IngredientHandler ih;
    public int num;

    void Start()
    {
        ih = this.GetComponent<IngredientHandler>();
    }

    public void Split(Transform knifeTransform)
    {
        Vector3 right = transform.right;

        for (int i = 0; i < num; i++)
        {
            float offset = i * 0.05f;
            Vector3 spawnPosition = transform.position + right * offset;

            GameObject child = Instantiate(childIngredient, spawnPosition, knifeTransform.rotation *= Quaternion.Euler(0, 0, 90));

            if (ih.state == status.dirty)
            {
                child.GetComponent<IngredientHandler>().DirtyObject();
            }
        }

        Destroy(gameObject);
    }
}

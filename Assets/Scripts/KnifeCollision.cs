using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCollision : MonoBehaviour
{
    private SFXPlaying source;

    void Start()
    {
        source = GameObject.FindGameObjectsWithTag("AudioManager")[0].GetComponent<SFXPlaying>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IngredientHandler>() && collision.relativeVelocity.y > 1.5f)
        {
            if (collision.gameObject.GetComponent<Cuttable>())
            {
                source.PlayCutting();
                collision.gameObject.GetComponent<Cuttable>().Split(this.gameObject.transform);

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCollision : MonoBehaviour
{
    public SFXPlaying source;

    void Start()
    {
        source = GameObject.FindGameObjectsWithTag("AudioManager")[0].GetComponent<SFXPlaying>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IngredientHandler>() && collision.relativeVelocity.y > 2)
        {
            Debug.Log(collision.gameObject.name);
            if (collision.gameObject.GetComponent<Cuttable>())
            {
                // Debug.Log("CUT");
                source.PlayCutting();
                collision.gameObject.GetComponent<Cuttable>().Split(this.gameObject.transform);

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCollision : MonoBehaviour
{
    public PlayerCut playerCut;
    public SFXPlaying source;

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

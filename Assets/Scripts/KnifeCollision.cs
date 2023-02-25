using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCollision : MonoBehaviour
{
    public PlayerCut playerCut;
    private Animator knifeAnim;

    void Start()
    {
        knifeAnim = this.gameObject.GetComponent<Animator>();
        knifeAnim.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IngredientHandler>() && collision.relativeVelocity.y > 2)
        {
            Debug.Log(collision.gameObject.name);
            if (collision.gameObject.GetComponent<Cuttable>())
            {
                collision.gameObject.GetComponent<Cuttable>().Split();
            }
        }
    }
}

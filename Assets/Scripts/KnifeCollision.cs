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

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IngredientHandler>() && playerCut.isAttacking)
        {
            Debug.Log(other.name);
            if (other.GetComponent<Cuttable>())
            {
                other.GetComponent<Cuttable>().Split();
            }
        }
    }
}

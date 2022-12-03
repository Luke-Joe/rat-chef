using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveTop : MonoBehaviour
{
    private int isTurnedOn;

    // Start is called before the first frame update
    void Start()
    {
        isTurnedOn = 0;
    }

    void TurnOn()
    {
        isTurnedOn = 1;
    }

    void OnCollisionStay(Collision other)
    {
        IngredientHandler obj = other.gameObject.GetComponent<IngredientHandler>();

        if (obj != null && isTurnedOn > 0)
        {
            switch (obj.state)
            {
                case status.raw:
                    if (obj.currCook < obj.cookTime)
                    {
                        obj.currCook += Time.deltaTime;
                        Debug.Log("Cooking " + other.gameObject.name + obj.currCook);
                    }
                    else
                    {
                        obj.state = status.cooked;
                    }
                    break;
                case status.cooked:
                    if (obj.currBurn < obj.burnTime)
                    {
                        obj.currBurn += Time.deltaTime;
                        Debug.Log("Burning " + other.gameObject.name + obj.currBurn);
                    }
                    else
                    {
                        obj.state = status.burnt;
                    }
                    break;
            }
        }
    }
}

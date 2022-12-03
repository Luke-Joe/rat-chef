using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveTop : MonoBehaviour
{
    public Transform stoveCheck;
    public float stoveDist = 0.4f;
    public LayerMask stoveMask;

    private int isTurnedOn;
    private bool isOiled;
    private bool isHeated;

    // Start is called before the first frame update
    void Start()
    {
        isTurnedOn = 1;
        isOiled = false;
    }

    void Update()
    {
        isHeated = Physics.CheckSphere(stoveCheck.position, stoveDist, stoveMask); //COMBINE THIS CHECK WITH BOOL THAT CHECKS IF STOVE IS ON
    }

    void OnCollisionStay(Collision other)
    {
        IngredientHandler obj = other.gameObject.GetComponent<IngredientHandler>();

        if (obj != null && isHeated)
        {
            if (isOiled && isHeated)
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
                            // TODO: Add slight delay between when an item is cooked and when it starts burning
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
            else
            {
                if (obj.currBurn < obj.burnTime)
                {
                    obj.currBurn += Time.deltaTime;
                    Debug.Log("Burning " + other.gameObject.name + obj.currBurn);
                }
                else
                {
                    obj.state = status.burnt;
                }
            }
        }
    }


}

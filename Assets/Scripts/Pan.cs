using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    //TODO: Pan should always land right side up/bounce into position/
    //alternatively, provide dedicated keys for rotating objects
    public Transform stoveCheck;
    public float stoveDist = 0.4f;
    public LayerMask stoveMask;

    private int isTurnedOn;
    private bool isOiled;
    private bool isHeated;
    private bool onStove;
    private Stove stove;

    // Start is called before the first frame update
    void Start()
    {
        isTurnedOn = 1;-0
        isOiled = false;
    }

    void Update()
    {
        //TODO: Create separate tag for stovemask 
        onStove = Physics.CheckSphere(stoveCheck.transform.position, 0.1f, stoveMask);
        Debug.Log("ON STOVE = " + onStove);
    }

    void OnCollisionStay(Collision other)
    {
        checkStove(other);
        IngredientHandler obj = other.gameObject.GetComponent<IngredientHandler>();

        // If ingredient in pan is heated, cook it if the pan is oiled. If not oiled, burn it.
        if (obj != null && onStove)
        {
            if (isOiled)
            {
                switch (obj.state)
                {
                    case status.raw:
                        if (obj.currCook < obj.cookTime)
                        {
                            obj.currCook += Time.deltaTime * stove.power;
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
                            obj.currBurn += Time.deltaTime * stove.power;
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

    //Checks if the pan is colliding with a stove 
    void checkStove(Collision other)
    {
        stove = other.gameObject.GetComponent<Stove>();

        if (stove != null)
        {
            onStove = true;
        }
        else
        {
            onStove = false;
        }
    }


}

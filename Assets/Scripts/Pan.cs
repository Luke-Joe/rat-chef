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

    public int currTemp;
    public bool isOiled;
    private Stove stove;

    // Start is called before the first frame update
    void Start()
    {
        currTemp = 0;
        isOiled = true;
    }

    void Update()
    {
        checkStove();
    }

    void OnCollisionStay(Collision other)
    {
        IngredientHandler obj = other.gameObject.GetComponent<IngredientHandler>();

        // If ingredient in pan is heated, cook it if the pan is oiled. If not oiled, burn it.
        if (obj != null && stove != null)
        {
            if (isOiled)
            {
                switch (obj.state)
                {
                    case status.raw:
                        if (obj.currCook < obj.cookTime)
                        {
                            obj.currCook += Time.deltaTime * currTemp;
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
                            obj.currBurn += Time.deltaTime * currTemp;
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

    // Checks if the pan is colliding with a stove 
    void checkStove()
    {
        Collider[] hitCollider = Physics.OverlapSphere(stoveCheck.transform.position, 0.1f, stoveMask);

        if (hitCollider == null || hitCollider.Length == 0) {
            // Pan is no longer on stove
            stove = null;
            currTemp = 0;
        } else {
            foreach (Collider collision in hitCollider) {
                stove = collision.gameObject.GetComponent<Stove>();

                currTemp = stove == null ? 0 : stove.power;
            }
        }
        
    }

    //Oils pan
    //TODO: decide on point when pan is no longer oiled (After ingredient cooks/burns)
    public void oilPan() {
        isOiled = true;
    }
}

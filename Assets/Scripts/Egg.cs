using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public GameObject splitOne;
    public GameObject splitTwo;
    public GameObject egg;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.y > 2)
        {
            //Egg is thrown into/on pan
            if (collision.gameObject.GetComponent<Pan>() != null)
            {
                Split();
            }
            else
            {
                Break();
            }
        }
    }

    void Split()
    {
        Instantiate(splitOne, this.transform.position, this.transform.rotation);
        Instantiate(splitTwo, this.transform.position, this.transform.rotation);
        Instantiate(egg, this.transform.position, this.transform.rotation);
    }

    void Break()
    {

    }
}

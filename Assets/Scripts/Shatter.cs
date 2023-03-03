using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject destroyedVersion;
    // void OnMouseDown() {
    //     Debug.Log("here");
    //     Instantiate(destroyedVersion, transform.position, transform.rotation);
    //     Destroy(gameObject);
    //     Debug.Log("here");
    // }

    void OnCollisionEnter(Collision col)
    {
       if (col.gameObject.name == "Plane") {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}

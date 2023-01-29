using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPour : MonoBehaviour
{
    [SerializeField]
    private PlayerPickup playerPickup;
    private GameObject heldObject;

    void Update()
    {
        heldObject = playerPickup.heldObject;

        if (heldObject != null && heldObject.GetComponent<PourDetector>())
        {
            heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;

            if (Input.GetButton("Fire2"))
            {
                RotatePourable(heldObject.GetComponent<PourDetector>().pourAngle);
            }
        }
    }

    void RotatePourable(float pourAngle)
    {
        //TODO: Rotate pourable object inwards until pourAngle
    }
}

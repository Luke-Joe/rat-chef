using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCut : MonoBehaviour
{
    [SerializeField]
    private PlayerPickup playerPickup;

    private GameObject heldObject;
    private Rigidbody heldObjectRB;

    private bool knifeHeld = false;

    void Start()
    {
        playerPickup = GetComponent<PlayerPickup>();
    }

    void Update()
    {
        heldObject = playerPickup.heldObject;

        if (heldObject != null && heldObject.gameObject.tag == "Knife")
        {
            if (!knifeHeld)
            {
                PickupKnife(heldObject);
            }
        }
        else
        {
            DropKnife();
        }
    }

    void PickupKnife(GameObject heldObject)
    {
        heldObjectRB = heldObject.GetComponent<Rigidbody>();
        heldObjectRB.constraints = RigidbodyConstraints.FreezeRotation;
        heldObjectRB.useGravity = false;
        heldObjectRB.drag = 10;
        knifeHeld = true;
    }

    void DropKnife()
    {
        knifeHeld = false;
    }
}

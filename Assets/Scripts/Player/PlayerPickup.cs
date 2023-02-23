using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform rightHandGrabPoint;
    [SerializeField] private LayerMask pickupLayerMask;

    public GameObject heldObject;
    private Rigidbody heldObjectRb;
    public float pickupForce = 15f;
    public float pickupDistance = 3f;

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (heldObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, pickupDistance, pickupLayerMask))
                {
                    PickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                MoveObject();
            }
        }
        else
        {
            if (heldObject != null)
            {
                DropObject();
            }
        }

        //TODO: Handle right click
    }

    void PickupObject(GameObject pickObject)
    {
        if (pickObject.GetComponent<Rigidbody>())
        {
            heldObjectRb = pickObject.GetComponent<Rigidbody>();
            heldObjectRb.useGravity = false;
            heldObjectRb.drag = 10;

            heldObject = pickObject;
        }
    }

    void DropObject()
    {
        heldObjectRb.useGravity = true;
        heldObjectRb.drag = 1;
        heldObjectRb.constraints = RigidbodyConstraints.None;

        heldObject = null;
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObject.transform.position, rightHandGrabPoint.position) > 0.1f)
        {
            Vector3 moveDirection = (rightHandGrabPoint.position - heldObject.transform.position);

            heldObjectRb.AddForce(moveDirection * pickupForce);
        }
    }
}

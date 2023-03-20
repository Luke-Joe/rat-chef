using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform rightHandGrabPoint;
    [SerializeField] private LayerMask pickupLayerMask;

    public GameObject heldObject;
    private Rigidbody heldObjectRb;
    public float pickupForce = 15f;
    public float pickupDistance = 3f;
    private bool holdingRat = false;

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

        RatPickup();
    }

    void DropObject()
    {
        RatDrop();
        heldObjectRb.useGravity = true;
        heldObjectRb.drag = 1;
        heldObjectRb.constraints = RigidbodyConstraints.None;
        heldObject = null;
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObject.transform.position, rightHandGrabPoint.position) > 0.01f)
        {
            Vector3 moveDirection = (rightHandGrabPoint.position - heldObject.transform.position);

            heldObjectRb.AddForce(moveDirection * pickupForce);
        }
    }

    void RatPickup()
    {

        if (heldObject.GetComponent<RatController>())
        {
            holdingRat = true;
            heldObject.GetComponent<NavMeshAgent>().enabled = false;
            heldObject.GetComponent<RatController>().DropFood();
            heldObject.GetComponent<RatController>().enabled = false;
        }
    }

    void RatDrop()
    {
        if (holdingRat)
        {
            heldObject.GetComponent<NavMeshAgent>().enabled = true;
            heldObject.GetComponent<RatController>().enabled = true;
            holdingRat = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerPickup2 : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform grabPoint;
    [SerializeField] private LayerMask pickupLayerMask;

    public GameObject heldObject;
    private Rigidbody heldObjectRb;
    public float pickupForce = 15f;
    public float pickupDistance = 3f;
    private bool holdingRat = false;
    public bool isHolding = false;
    public float lerpSpeed = 5f;
    private int layerNumber;

    void Start()
    {
        layerNumber = LayerMask.NameToLayer("No Clip");
    }

    void Update()
    {
        InputHandler();
    }

    void FixedUpdate()
    {
        if (isHolding && heldObject != null)
        {
            Vector3.Lerp(transform.position, grabPoint.position, Time.deltaTime * lerpSpeed);
        }
    }

    private void InputHandler()
    {
        if (Input.GetButton("Fire1"))
        {
            if (heldObject == null)
            {
                if (!isHolding)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, pickupDistance, pickupLayerMask))
                    {
                        PickupObject(hit.transform.gameObject);
                    }
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

    void MoveObject()
    {
        heldObject.transform.position = grabPoint.transform.position;
    }

    void PickupObject(GameObject pickObject)
    {
        if (pickObject.GetComponent<Rigidbody>())
        {
            heldObject = pickObject;
            heldObjectRb = pickObject.GetComponent<Rigidbody>();
            heldObjectRb.useGravity = false;
            heldObjectRb.transform.parent = grabPoint.transform;
            heldObject.layer = layerNumber;
            isHolding = true;
        }

        // RatPickup();
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            heldObject.layer = 7;
            heldObjectRb.useGravity = true;
            heldObject.transform.parent = null;
            heldObject = null;
            isHolding = false;
        }
    }

    // void RatPickup()
    // {

    //     if (heldObject.GetComponent<RatController>())
    //     {
    //         holdingRat = true;
    //         heldObject.GetComponent<NavMeshAgent>().enabled = false;
    //         heldObject.GetComponent<RatController>().DropFood();
    //         heldObject.GetComponent<RatController>().enabled = false;
    //     }
    // }

    // void RatDrop()
    // {
    //     if (holdingRat)
    //     {
    //         heldObject.GetComponent<NavMeshAgent>().enabled = true;
    //         heldObject.GetComponent<RatController>().enabled = true;
    //         holdingRat = false;
    //     }
    // }
}

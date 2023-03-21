using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPour : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    private GameObject heldObject;
    private PlayerPickup playerPickup;

    void Start()
    {
        playerPickup = this.GetComponent<PlayerPickup>();
    }

    void Update()
    {
        heldObject = playerPickup.heldObject;

        if (heldObject != null && heldObject.GetComponent<PourDetector>())
        {
            if (Input.GetButton("Fire2"))
            {
                // RotatePourable();
            }
            else
            {
                // RevertRotation();
            }
        }
    }

    void RotatePourable()
    {
        //NOTE: Attempted to make pour angle adjustable. I'm terrible with Vectors\Lin alg, so for now, it's just stuck at 45 downwards.
        Quaternion startRotation = heldObject.transform.rotation;
        Quaternion endRotation = Quaternion.LookRotation(-Camera.main.transform.forward, -Camera.main.transform.right - Camera.main.transform.up);
        heldObject.transform.rotation = Quaternion.Slerp(startRotation, endRotation, rotateSpeed * Time.deltaTime);
    }

    void RevertRotation()
    {
        Quaternion startRotation = heldObject.transform.rotation;
        Quaternion endRotation = Quaternion.LookRotation(-Camera.main.transform.forward, Camera.main.transform.up);
        heldObject.transform.rotation = Quaternion.Slerp(startRotation, endRotation, rotateSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInspect : MonoBehaviour
{
    public float rotateSpeed = 1f;

    [SerializeField] private Transform grabPoint;
    private PlayerPickup pp;
    private GameObject heldObject;
    private LookController lc;
    private bool isInspecting;
    private bool isRotating;
    private Camera cam;

    void Start()
    {
        pp = GetComponent<PlayerPickup>();
        lc = GetComponentInChildren<LookController>();
        cam = GetComponentInChildren<Camera>();

        isInspecting = false;
        isRotating = false;
    }

    void Update()
    {
        heldObject = pp.heldObject;

        if (Input.GetButton("Fire2") && !isRotating && heldObject != null && !heldObject.GetComponent<PourDetector>())
        {
            float x = Input.GetAxis("Mouse X") * rotateSpeed;
            float y = Input.GetAxis("Mouse Y") * rotateSpeed;

            heldObject.transform.Rotate(-cam.transform.up * x, Space.World);
            heldObject.transform.Rotate(cam.transform.right * y, Space.World);

            isInspecting = true;
            lc.enabled = false;
            grabPoint.transform.rotation = heldObject.transform.rotation;
        }
        else
        {
            if (Input.GetKey(KeyCode.R) && heldObject != null && !heldObject.GetComponent<PourDetector>() && !isInspecting)
            {
                lc.enabled = false;

                float x = Input.GetAxis("Mouse X") * rotateSpeed;

                heldObject.transform.Rotate(-cam.transform.forward * x, Space.World);

                isRotating = true;
                grabPoint.transform.rotation = heldObject.transform.rotation;
            }
            else
            {
                isRotating = false;
                isInspecting = false;
                lc.enabled = true;
            }
        }
    }
}

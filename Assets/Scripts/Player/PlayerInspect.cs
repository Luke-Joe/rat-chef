using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInspect : MonoBehaviour
{
    private PlayerPickup pp;
    private GameObject heldObject;
    private LookController lc;
    private bool isInspecting;
    [SerializeField] private Transform rightHandGrabPoint;
    public float rotateSpeed = 1f;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        pp = GetComponent<PlayerPickup>();
        lc = GetComponentInChildren<LookController>();
        cam = GetComponentInChildren<Camera>();

        isInspecting = false;
        heldObject = pp.heldObject;
    }

    // Update is called once per frame
    void Update()
    {
        heldObject = pp.heldObject;

        if (Input.GetButton("Fire2") && heldObject != null && !heldObject.GetComponent<PourDetector>())
        {
            float x = Input.GetAxis("Mouse X") * rotateSpeed;
            float y = Input.GetAxis("Mouse Y") * rotateSpeed;

            heldObject.transform.Rotate(-cam.transform.up * x, Space.World);
            heldObject.transform.Rotate(cam.transform.right * y, Space.World);

            rightHandGrabPoint.transform.rotation = heldObject.transform.rotation;

            isInspecting = true;
            lc.enabled = false;
            // Debug.Log("I WANT TO ROTATE THE HELD OBJECT");
        }
        else
        {
            isInspecting = false;
            lc.enabled = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Rotating");
        heldObject.transform.eulerAngles = new Vector3(eventData.delta.y, -eventData.delta.x);

    }
}

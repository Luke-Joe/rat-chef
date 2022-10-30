using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody rb;
    private Transform grabPoint;
    public float speed = 50f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Grab(Transform grabPoint)
    {
        this.grabPoint = grabPoint;
        rb.useGravity = false;
    }

    private void FixedUpdate()
    {
        if (grabPoint != null)
        {
            Vector3 newPos = Vector3.Lerp(transform.position, grabPoint.position, Time.deltaTime * speed);
            rb.MovePosition(newPos);
        }
    }
}

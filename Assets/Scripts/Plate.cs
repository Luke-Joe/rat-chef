using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    Rigidbody rb;
    BoxCollider plateZone;

    public LayerMask grabbableMask;

    public List<GameObject> Carryable;

    private bool isCarrying;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        plateZone = GetComponent<BoxCollider>();
        Carryable = new List<GameObject>();
        isCarrying = false;
    }

    void Update()
    {
        if (isCarrying)
        {
            for (int i = 0; i < Carryable.Count; i++)
            {
            }
        }
    }

    public void Carry()
    {
        for (int i = 0; i < Carryable.Count; i++)
        {
            Debug.Log("Carrying " + Carryable[0].transform.name);
            Carryable[0].transform.parent = this.gameObject.transform;
            Rigidbody itemRb = Carryable[0].GetComponent<Rigidbody>();
            if (itemRb != null)
            {
                itemRb.useGravity = true;
                itemRb.mass = 0;
            }
        }

        isCarrying = true;
        plateZone.enabled = false;
    }

    public void Release()
    {
        if (Carryable.Count == 0)
        {
            return;
        }

        for (int i = 0; i < Carryable.Count; i++)
        {
            Carryable[0].transform.parent = null;
            Rigidbody itemRb = Carryable[0].GetComponent<Rigidbody>();
            if (itemRb != null)
            {
                itemRb.useGravity = true;
                itemRb.mass = 1;
            }
        }
    }

    public void ReleaseItem(GameObject toRelease)
    {
        Rigidbody itemRb = toRelease.GetComponent<Rigidbody>();

        toRelease.transform.parent = null;
        if (itemRb != null)
        {
            itemRb.useGravity = true;
            itemRb.mass = 1;
        }

        isCarrying = false;
        plateZone.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if ((grabbableMask.value & 1 << other.gameObject.layer) != 0)
        {
            Carryable.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Carryable.Remove(other.gameObject);
        ReleaseItem(other.gameObject);
    }
}

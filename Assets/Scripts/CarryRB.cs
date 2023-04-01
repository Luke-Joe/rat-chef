using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryRB : MonoBehaviour
{
    public List<Rigidbody> rbs = new List<Rigidbody>();

    public Vector3 lastPosition;
    private Transform tf;

    // Start is called before the first frame update
    void Start()
    {
        tf = transform;
        lastPosition = tf.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        for (int i = 0; i < rbs.Count; i++)
        {
            Rigidbody rb = rbs[i];
            Vector3 velocity = (tf.position - lastPosition);
            rb.transform.Translate(velocity, tf);
        }

        lastPosition = tf.position;
    }

    void OnCollisionEnter(Collision c)
    {
        Rigidbody rb = c.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.mass = 0;
            Add(rb);
        }
    }

    void OnCollisionExit(Collision c)
    {
        Rigidbody rb = c.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.mass = 1;
            Remove(rb);
        }
    }

    void Add(Rigidbody rb)
    {
        if (!rbs.Contains(rb))
        {
            rbs.Add(rb);
        }
    }

    void Remove(Rigidbody rb)
    {
        if (rbs.Contains(rb))
        {
            rbs.Remove(rb);
        }
    }
}

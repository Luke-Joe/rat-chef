using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatController : MonoBehaviour
{
    private NavMeshAgent agent;
    public IngredientHandler food;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform ratMouth;
    [SerializeField] private Transform home;

    private bool hasFood;
    private Vector3 movePosition;
    private GameObject heldObject;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!hasFood)
        {
            movePosition = food.transform.position;
        }
        else
        {
            movePosition = home.position;
            MoveFood();
        }

        SeekTarget(movePosition);
    }

    void SeekTarget(Vector3 target)
    {
        agent.destination = target;
        Vector3 lookDir = target - transform.position + new Vector3(0, 0, 0);
        lookDir.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IngredientHandler>() != null && !hasFood)
        {
            GrabFood(collision.gameObject);
        }
    }

    void GrabFood(GameObject food)
    {
        hasFood = true;
        heldObject = food;
        Rigidbody foodRb = food.GetComponent<Rigidbody>();
        foodRb.useGravity = false;
        food.transform.SetParent(ratMouth);
    }

    void MoveFood()
    {
        heldObject.transform.position = ratMouth.transform.position;
        heldObject.transform.rotation = ratMouth.transform.rotation;
    }

    public void DropFood()
    {
        hasFood = false;
        Rigidbody foodRb = heldObject.GetComponent<Rigidbody>();
        foodRb.useGravity = true;
        foodRb.isKinematic = false;
        heldObject.transform.SetParent(null);
        heldObject = null;
    }
}

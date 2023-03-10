using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Benny : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform food;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform ratMouth;
    [SerializeField] private Transform home;

    private bool hasFood;
    private Vector3 movePosition;
    private GameObject heldObject;

    [Header("Patrolling")]
    [SerializeField] private float range;
    [SerializeField] private float sightRange;
    [SerializeField] private float vertRange;
    [SerializeField] private float ratThrowForce;

    public enum MoveState
    {
        searching,
        chasing,
        returning
    }

    private MoveState state;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        StateCheck();
        StateHandler();
    }

    void StateCheck()
    {
        if (!hasFood)
        {
            if (food == null || food.position.y > vertRange)
            {
                state = MoveState.searching;
            }
            else
            {
                state = MoveState.chasing;
            }
        }
        else
        {
            state = MoveState.returning;
        }
    }

    void StateHandler()
    {
        switch (state)
        {
            case MoveState.searching:
                movePosition = home.position;
                Look();
                break;
            case MoveState.chasing:
                movePosition = food.position;
                break;
            case MoveState.returning:
                movePosition = home.position;
                MoveFood();
                Look();
                CompletionCheck();
                break;
        }

        ChaseTarget(movePosition);
    }

    void Look()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, sightRange);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.GetComponent<IngredientHandler>() != null && hitCollider.transform.position.y < vertRange)
            {
                food = hitCollider.gameObject.transform;
            }
        }
    }

    void CompletionCheck()
    {
        if (Vector3.Distance(home.transform.position, gameObject.transform.position) <= 2.5f)
        {
            DropFood();
        }
    }

    void ChaseTarget(Vector3 target)
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
        foodRb.AddForce(transform.forward * ratThrowForce, ForceMode.Impulse);
        heldObject.transform.SetParent(null);
        heldObject = null;
    }
}

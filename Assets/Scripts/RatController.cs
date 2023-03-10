using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatController : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform food;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform ratMouth;
    [SerializeField] private Transform home;
    [SerializeField] private Transform despawnZone;

    private bool hasFood;
    private bool isCompleted;
    private Vector3 movePosition;
    private GameObject heldObject;

    [Header("Patrolling")]
    [SerializeField]
    private float range;
    [SerializeField]
    private float sightRange;
    [SerializeField]
    private float vertRange;
    [SerializeField]
    private float patrolTime;
    [SerializeField]
    private float ratThrowForce;
    private float currPatrolTime;

    public enum MoveState
    {
        searching,
        chasing,
        returning,
        completed
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
        if (isCompleted)
        {
            state = MoveState.completed;
            return;
        }

        if (!hasFood)
        {
            if (food == null || food.position.y > vertRange)
            {
                state = MoveState.searching;

                if (currPatrolTime <= 0.0f)
                {
                    state = MoveState.returning;
                }
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
                Search();
                Look();
                break;
            case MoveState.chasing:
                movePosition = food.position;
                break;
            case MoveState.returning:
                movePosition = home.position;
                MoveFood();
                CompletionCheck();
                break;
            case MoveState.completed:
                movePosition = despawnZone.position;
                DespawnCheck();
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

    void Search()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 point;

            if (RandomPoint(transform.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
            }
        }

        currPatrolTime -= Time.deltaTime;
    }

    void CompletionCheck()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            DropFood();
            isCompleted = true;
        }
    }

    void DespawnCheck()
    {
        Debug.Log(Vector3.Distance(gameObject.transform.position, despawnZone.position));
        if (Vector3.Distance(gameObject.transform.position, despawnZone.position) < 0.5f)
        {
            Destroy(gameObject);
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }

        result = Vector3.zero;
        return false;
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

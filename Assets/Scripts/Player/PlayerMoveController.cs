using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;

    public Vector3 velocity;
    public LayerMask groundMask;

    [Header("Moving")]
    private float currSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    [SerializeField] private float pushForce = 10f;

    [Header("Jumping")]
    public float groundDist = 0.4f;
    public float gravity = -3f;
    public float jumpHeight = 0.003f;
    private bool isGrounded;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

    [Header("Keybinds")]
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    public MoveState state;

    public enum MoveState
    {
        walking,
        sprinting,
        crouching,
        air
    }

    void Start()
    {
        startYScale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        GroundChecker();
        StateHandler();
        InputHandler();

        controller.Move(velocity);
    }

    void InputHandler()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * currSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
        }

        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
    }

    void StateHandler()
    {
        if (Input.GetKey(crouchKey))
        {
            state = MoveState.crouching;
            currSpeed = crouchSpeed;
        }

        else if (isGrounded && Input.GetKey(sprintKey))
        {
            state = MoveState.sprinting;
            currSpeed = sprintSpeed;
        }

        else if (isGrounded)
        {
            state = MoveState.walking;
            currSpeed = walkSpeed;
        }

        else
        {
            state = MoveState.air;
        }
    }

    void GroundChecker()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.0001f;
        }

        velocity.y += gravity * Time.deltaTime;
    }

    // Push any gameobjects that come into collision with the player. 
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb != null && !rb.isKinematic)
        {
            // rb.velocity = hit.moveDirection * pushForce;
            rb.AddForce(hit.moveDirection * pushForce);
        }
    }
}

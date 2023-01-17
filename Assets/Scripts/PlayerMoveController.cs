using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;

    public Vector3 velocity;
    public LayerMask groundMask;
    public float groundDist = 0.4f;
    public float speed = 5f;
    public float gravity = -3f;
    public float jumpHeight = 0.003f;

    private bool isGrounded;
    [SerializeField] private float pushForce = 10f;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.0001f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity);
    }

    // Push any gameobjects that come into collision with the player. 
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb != null && !rb.isKinematic)
        {
            // rb.velocity = hit.moveDirection * pushForce;
            rb.AddForce(hit.moveDirection * pushForce);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToggle : MonoBehaviour
{
    // NOTE: Make sure initial parameter id for all toggleable objects checks if its on (??? I have no idea what this means now)
    [SerializeField] Transform playerCameraTransform;
    [SerializeField] LayerMask interactableLayerMask;

    public GameObject Instruction;
    private float interactDistance = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Instruction.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit hit, interactDistance, interactableLayerMask))
        {
            ToggleDoor(hit);
        }
        else
        {
            Instruction.SetActive(false);
        }
    }

    void ToggleDoor(RaycastHit hit)
    {
        if (hit.collider.GetComponentInParent<Door>())
        {
            Door door = hit.collider.GetComponentInParent<Door>();
            Instruction.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (door.isOpen)
                {
                    door.Close();
                }
                else
                {
                    door.Open();
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // NOTE: Make sure initial parameter id for all toggleable objects checks if its on
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
        else
        {
            Instruction.SetActive(false);
        }
    }
}

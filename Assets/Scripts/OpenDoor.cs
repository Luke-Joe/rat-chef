using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // NOTE: Make sure initial parameter id for all toggleable objects checks if its on
    [SerializeField] Transform playerCameraTransform;
    [SerializeField] LayerMask interactableLayerMask;

    public GameObject animationObject;
    public GameObject Instruction;
    private bool Action = false;
    private float interactDistance = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Instruction.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, interactDistance, interactableLayerMask)) {
            Action = true;
            Instruction.SetActive(true);
        } else {
            Action = false;
            Instruction.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.E)) {
            if (Action) {
                Instruction.SetActive(false);
                Animator anim = animationObject.GetComponent<Animator>();
                anim.SetBool("isOn", !anim.GetBool("isOn"));
            }
    }
}
}

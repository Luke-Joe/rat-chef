using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCut : MonoBehaviour
{
    [SerializeField]
    private PlayerPickup playerPickup;
    [SerializeField]
    private GameObject knifePosition;

    private GameObject heldObject;
    private Rigidbody heldObjectRB;
    private Animator heldObjectAnim;

    public bool canAttack = true;
    public float attackCd = 0.5f;
    public bool isAttacking = false;
    private bool knifeHeld = false;

    // Update is called once per frame
    void Update()
    {
        heldObject = playerPickup.heldObject;

        if (heldObject != null && heldObject.gameObject.tag == "Knife")
        {
            if (!knifeHeld)
            {
                PickupKnife(heldObject);
            }

            if (Vector3.Distance(heldObject.transform.position, knifePosition.transform.position) < 1f)
            {
                // MoveKnife(heldObject);
            }


            //     if (Input.GetButton("Fire2") && canAttack)
            //     {
            //         Cut();
            //     }

        }
        else
        {
            DropKnife();
        }
    }

    void PickupKnife(GameObject heldObject)
    {
        heldObjectRB = heldObject.GetComponent<Rigidbody>();
        // heldObject.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Vector3.forward);
        // heldObject.transform.parent = knifePosition.transform;
        // heldObjectAnim = heldObject.GetComponent<Animator>();
        // heldObjectAnim.enabled = true;
        heldObjectRB.constraints = RigidbodyConstraints.FreezeRotation;
        heldObjectRB.useGravity = false;
        heldObjectRB.drag = 10;
        knifeHeld = true;
    }

    void DropKnife()
    {
        // foreach (Transform child in knifePosition.transform)
        // {
        //     if (child.GetComponent<Rigidbody>() != null)
        //     {
        //         Rigidbody childRB = child.GetComponent<Rigidbody>();
        //         childRB.constraints = RigidbodyConstraints.None;
        //         childRB.useGravity = true;
        //         childRB.drag = 1;
        //         child.GetComponent<Animator>().enabled = false;
        //     }
        //     child.gameObject.transform.parent = null;
        // }
        knifeHeld = false;
    }

    // void Cut()
    // {
    //     canAttack = false;
    //     isAttacking = true;
    //     // heldObjectAnim.enabled = true;
    //     StartCoroutine(refreshAttackCooldown());
    //     // heldObjectAnim.SetTrigger("Attack");
    //     //Plays cutting animation, sound, etc.
    // }

    // IEnumerator refreshAttackCooldown()
    // {
    //     StartCoroutine(ResetAttackBool());
    //     yield return new WaitForSeconds(attackCd);
    //     canAttack = true;
    //     // heldObjectAnim.SetBool("Attack", false);
    //     // heldObjectAnim.enabled = false;
    // }

    // IEnumerator ResetAttackBool()
    // {
    //     yield return new WaitForSeconds(attackCd);
    //     isAttacking = false;
    // }


}

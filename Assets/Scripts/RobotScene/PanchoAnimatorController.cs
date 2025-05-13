using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanchoAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovementPrueba _panchoMovement;

    void Update()
    {
        //Run
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            _animator.SetBool("Run", true);
        else
            _animator.SetBool("Run", false);

        //Jump
        if (_panchoMovement.isGrounded == false)
            _animator.SetBool("Grounded", false);
        if (_panchoMovement.isGrounded == true)
            _animator.SetBool("Grounded", true);

        //Attack
        if (Input.GetKeyUp(KeyCode.Mouse0))
            _animator.SetTrigger("Attack");

        //Block
        if (Input.GetKey(KeyCode.F))
            _animator.SetBool("Block", true);
        if (Input.GetKeyUp(KeyCode.F))
            _animator.SetBool("Block", false);
    }
}

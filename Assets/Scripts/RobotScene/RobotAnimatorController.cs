using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimatorController : MonoBehaviour
{
    //Attributes
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovementPrueba _robotMovement;

    //Methods
    void Update()
    {
        // Set Animator Properties State

        //Run
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            _animator.SetBool("Run", true);
        else
            _animator.SetBool("Run", false);

        //Shoot
        if (Input.GetKeyUp(KeyCode.Mouse0))
            _animator.SetTrigger("Attack");

        //Hit
        if (Input.GetKeyUp(KeyCode.E))
            _animator.SetTrigger("Hit");

        //Jump
        if (_robotMovement.isGrounded == false)
            _animator.SetBool("Grounded", false);
        if (_robotMovement.isGrounded == true)
            _animator.SetBool("Grounded", true);

        //Duck
        if (Input.GetKey(KeyCode.S))
            _animator.SetBool("Duck", true);
        else
            _animator.SetBool("Duck", false);
    }
}

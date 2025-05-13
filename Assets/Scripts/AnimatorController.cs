using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    [field: SerializeField] private Button _propulsorL; 
    [field: SerializeField] private Button _propulsorR; 
    private Jetpack _jetpack;
    private PlayerMovement _playerMovement;
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _jetpack = GetComponent<Jetpack>();
        _playerMovement = GetComponent<PlayerMovement>();
    }
    private void Start()
    {
        _propulsorL.onClick.AddListener(OnPropulsorLPressed);
        _propulsorR.onClick.AddListener(OnPropulsorRPressed);
    }


    void Update()
    {
        // Flying animation
        _anim.SetBool("Flying", _jetpack._flying);

        //Fall animation
        _anim.SetBool("Falling", _jetpack._fall);

        //Running animation
        if (_playerMovement._leftButtonController.IsMovingLeft || _playerMovement._rightButtonController.IsMovingRight)
            _anim.SetBool("Running", true);
        else
            _anim.SetBool("Running", false);
    }

    //Side Propulsion Animation
    private void OnPropulsorLPressed()
    {
        _anim.SetTrigger("SidePropulsor");
    }
    
    private void OnPropulsorRPressed()
    {
        _anim.SetTrigger("SidePropulsor");
    }
}

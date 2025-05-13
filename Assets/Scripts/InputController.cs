using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    [SerializeField] private Jetpack _jetpack;
    [SerializeField] private PlayerMovement _playerMovement;
    [field: SerializeField] private ButtonController _leftButtonController;
    [field: SerializeField] private ButtonController _rightButtonController;
    [field: SerializeField] private ButtonController _flyButtonController;
    [field: SerializeField] public Button _propulsorL;
    [field: SerializeField] public Button _propulsorR;

    private void Start()
    {
        _propulsorL.onClick.AddListener(() =>
        {
            PropulsorL();
        });
        
        _propulsorR.onClick.AddListener(() =>
        {
            PropulsorR();
        });
    }
    void Update()
    {
        if (_rightButtonController.IsMovingRight)
        {
            //Horizontal Fly
            _jetpack.FlyHorizontal(Jetpack.Direction.Right);

            //Moving while falling
            _jetpack.Falling(Jetpack.Direction.Right);

            //Look at the left/right
            _playerMovement._changeSide = true;
        }
        if (_leftButtonController.IsMovingLeft)
        {
            //Horizontal Fly
            _jetpack.FlyHorizontal(Jetpack.Direction.Left);

            //Moving while falling
            _jetpack.Falling(Jetpack.Direction.Left);

            //Look at the left/right
            _playerMovement._changeSide = false;
        }

        //Vertical Fly
        if (_flyButtonController.IsFlying)
            _jetpack.FlyUp();
        else
            _jetpack.StopFlying();
    }

    private void PropulsorL()
    {
        if (_playerMovement._changeSide == false)
            _playerMovement._changeSide = true;

        _jetpack.SidePropulsorLeft();
    }

    private void PropulsorR()
    {
        if (_playerMovement._changeSide == true)
            _playerMovement._changeSide = false;
        _jetpack.SidePropulsorRight();
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Attributes
    private PlayerDetections _playerDetections;
    [field: SerializeField] public ButtonController _leftButtonController;
    [field: SerializeField] public ButtonController _rightButtonController;
    private float _speedWalk = 5;
    public bool _changeSide;
    public bool canRun;

    private void Awake()
    {
        _playerDetections = GetComponent<PlayerDetections>();
    }

    void Update()
    {
        //Left/Right Movement
        if (_playerDetections.IsGrounded)
        {
            if (_rightButtonController.IsMovingRight) // Si el botón de la derecha está presionado
            {
                transform.Translate(Vector3.right * Time.deltaTime * _speedWalk);
            }
            else if (_leftButtonController.IsMovingLeft) // Si el botón de la izquierda está presionado
            {
                transform.Translate(Vector3.left * Time.deltaTime * _speedWalk);
            }
        }

        if (_changeSide == true) // LOOK AT THE RIGHT -->
            transform.localScale = new Vector2(2.321854f, 2.321854f);

        if (_changeSide == false) //LOOK AT THE LEFT <--
            transform.localScale = new Vector2(-2.321854f, 2.321854f);
    }
}

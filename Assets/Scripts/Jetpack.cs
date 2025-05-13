using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jetpack : MonoBehaviour
{
    //Enums
    public enum Direction
    {
        Left,
        Right
    }

    //Attributes
    public float Energy
    {
        get
        {
            return _energy;
        }
        set
        {
            _energy = Mathf.Clamp(value, 0, _maxEnergy);
        }
    }
    public bool _flying = false;
    public bool _fall;
    private Rigidbody2D _targetRB;
    private PlayerDetections _playerDetections;
    [SerializeField] private float _energy;
    [SerializeField] private float _maxEnergy;
    [SerializeField] private float _energyFlyingRatio;
    [SerializeField] private float _energyRegenerationRatio = 3f;
    [SerializeField] private float _horizontalForce;
    [SerializeField] private float _flyForce;
    [SerializeField] private float _propulsorForce = 10000;

    //Methods
    private void Awake()
    {
        _targetRB = GetComponent<Rigidbody2D>();
        _playerDetections = GetComponent<PlayerDetections>();
    }

    private void Start()
    {
        Energy = _maxEnergy;
    }

    private void Update()
    {
        IsFalling();
    }

    private void FixedUpdate()
    {
        if (_flying)
        {
            DoFly();
        }

        if (_playerDetections.IsGrounded)
            Regenerate();
    }

    //Public Methods
    public void FlyUp()
    {
        if (Energy <= 0)
            return;

        _flying = true;
    }

    public void StopFlying()
    {
        _flying = false;
    }

    public void Regenerate()
    {
        Energy += _energyRegenerationRatio * Time.deltaTime;
    }

    public void AddEnergy(float energy)
    {
        Energy += energy;
    }

    public void FlyHorizontal(Direction flyDirection)
    {
        if (!_flying)
            return;

        if (flyDirection == Direction.Left)
            _targetRB.AddForce(Vector2.left * _horizontalForce);
        else
            _targetRB.AddForce(Vector2.right * _horizontalForce);
    }

    public void IsFalling()
    {
        if (_flying == false && _playerDetections.IsGrounded == false)
            _fall = true;
        else
            _fall = false;
    }

    public void Falling(Direction flyDirection)
    {
        if (_fall)
        {
            if (flyDirection == Direction.Left)
                _targetRB.AddForce(Vector2.left * _horizontalForce);
            else
                _targetRB.AddForce(Vector2.right * _horizontalForce);
        }
    }

    public void SidePropulsorLeft()
    {
        if (_playerDetections.IsGrounded == false && Energy >= 5)
        {
            _targetRB.velocity = Vector2.zero;
            _targetRB.AddForce(Vector2.left * _propulsorForce);
            Energy -= 5;
        }
    }

    public void SidePropulsorRight()
    {
        if (_playerDetections.IsGrounded == false && Energy >= 5)
        {
            _targetRB.velocity = Vector2.zero;
            _targetRB.AddForce(Vector2.right * _propulsorForce);
            Energy -= 5;
        }
    }

    //Private Methods
    private void DoFly()
    {
        if (Energy > 0)
        {
            _targetRB.AddForce(Vector2.up * _flyForce);
            Energy -= _energyFlyingRatio;
        }
        else
            StopFlying();
    }

}

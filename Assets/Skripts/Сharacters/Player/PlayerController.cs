using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour //переименовать данный метод
{
    [SerializeField] private PlayerSound _sound;
    [SerializeField] private PlayerEffects _effects;
    [SerializeField] private MoveSourceController _moveSourseController;

    private Rigidbody2D _rigidbody;
    private InputActionControls _input;
    private PlayerSkills _skills;
    private Vector2 _directionToMouse;
    private Vector2 _mousePosition;
    private Vector2 _moveDirection;
    private float _lastShootTime;
    private float _brakingSpeed = 2f;
    private float _shoot;

    //очень много переменных содержит данный класс. ≈го надо разделить на неколько подклассов, которые будут отвечать за передвижение, повороты и выстрел

    private float _shootDelay => _skills.ShootDelay;
    private Bullet _bullet => _skills.Bullet;
    private float _speedAcceleration => _skills.Speed;

    public event UnityAction<bool> IsMoving;


    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _skills = GetComponent<PlayerSkills>();
        _input = new InputActionControls();

        _input.Enable();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void FixedUpdate()
    {
        Move(_moveDirection);
    }

    void Update()
    {
        _shoot = _input.PlayerActionMap.Shoot.ReadValue<float>();
        Shoot();
        _moveDirection = _input.PlayerActionMap.Move.ReadValue<Vector2>();
        _lastShootTime -= Time.deltaTime;
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Rotate();
    }

    private void OnDisable()
    {
        _input.Disable();
        _moveDirection = Vector2.zero;
        _effects.enabled = true;
    }

    private void Move(Vector2 _direction) // Ќадо разделить на 2 метода. ќдин отвечает за торможение, другой за передвижение
    {
        if (_direction != Vector2.zero)
        {
            _effects.EngineEffect.Play();

            IsMoving?.Invoke(true);

            Vector2 sidewaysDirection = new Vector2(transform.right.x, transform.right.y).normalized * _direction.y;

            Vector2 backwardDirection = -(transform.up) * _direction.x;

            _rigidbody.AddForce(sidewaysDirection * _speedAcceleration);
            _rigidbody.AddForce(backwardDirection * _speedAcceleration / 2);

        }
        else
        {
            _effects.EngineEffect.Stop();

            IsMoving?.Invoke(false);
            Vector2 oppositeForce = -_rigidbody.velocity * _brakingSpeed;
            _rigidbody.AddForce(oppositeForce);
            
        }
    }

    private void Rotate()
    {
        _directionToMouse = (_mousePosition - _rigidbody.position).normalized;
        float angle = Mathf.Atan2(_directionToMouse.y, _directionToMouse.x) * Mathf.Rad2Deg;
        _rigidbody.rotation = angle;
    }

    private void Shoot() // “ак как эта проверка довольно сложна€, можно сделать дл€ нее отдельный метод?
    {
        if (_lastShootTime <= 0 && _shoot !=0)
        {
            _sound.PlaySound(_sound.Shoot);
            Bullet bullet = Instantiate(_bullet, transform.position, Quaternion.identity); // ћожет тут паттерн фабрика поможет.
            bullet.Fire(_directionToMouse);
            _lastShootTime = _shootDelay;
        }
    }
}
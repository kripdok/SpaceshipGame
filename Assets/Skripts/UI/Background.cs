using UnityEngine;

public class Background : MonoBehaviour // 1. переименовать
    //2. Система выглядет очень переусложненой и плохло четабильной, за счет длинных расчетов камеры.
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxMoveRadius;


    private InputActionControls _input;
    private Vector2 _direction = Vector2.zero;
    private Vector2 _targetPosition;
    private Vector2 _startPosition;
    private float _speedModifier = 0;

    private void Start()
    {
        _startPosition = transform.position;
        _input = new InputActionControls();
        _input.Enable();
    }

    private void Update()
    {
        if (IsMove())
        {
            _direction = UpdateDirectionBasedOnMouse();
        }

        _targetPosition = UpdateTargetPosition(_direction);
        UpdateTargetPosition(_direction);
        MoveTovardTarget();
    }

    private Vector2 UpdateTargetPosition(Vector2 direction)
    {
        float moveFraction = Mathf.Clamp01(Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.position) / Screen.width);
        Vector2 position = _startPosition + direction * _maxMoveRadius * moveFraction;

        if (Vector2.Distance(_startPosition, _targetPosition) > _maxMoveRadius)
        {
            _targetPosition = _startPosition + (direction.normalized * _maxMoveRadius);
        }

        return position;
    }

    private void MoveTovardTarget()
    {
        float distanceToCenter = Vector2.Distance(transform.position, _startPosition);

        if (IsMove())
        {
            float Modifier = Mathf.Clamp01(1 - (distanceToCenter / _maxMoveRadius));
            _speedModifier = Mathf.Lerp(_speedModifier, Modifier, Time.deltaTime);
        }
        else
        {
            _speedModifier = Mathf.Lerp(_speedModifier, 0, Time.deltaTime * _speed);
        }

        transform.position = Vector2.Lerp(transform.position, _targetPosition, _speedModifier * Time.deltaTime);
    }

    private Vector2 UpdateDirectionBasedOnMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return (mousePos - Camera.main.transform.position).normalized;
    }

    private bool IsMove()
    {
        return _input.PlayerActionMap.Move.ReadValue<Vector2>() != Vector2.zero;
    }
}
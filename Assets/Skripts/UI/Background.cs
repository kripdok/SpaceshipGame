using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxMoveRadius;
    [SerializeField] private Camera _camera;

    private Vector3 _cameraPosition;
    private InputActionControls _input;
    private Vector2 _direction = Vector2.zero;
    private Vector2 _targetPosition;
    private Vector2 _startPosition;
    private float _speedModifier = 0;

    private void Start()
    {
        _startPosition = transform.position;
        _cameraPosition = _camera.transform.position;
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
        MoveTovardTarget();
    }

    private Vector2 UpdateDirectionBasedOnMouse()
    {
        Vector3 mousePos = MouseScreenPosition();
        return (mousePos - _cameraPosition).normalized;
    }

    private Vector3 MouseScreenPosition()
    {
        return _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private Vector2 UpdateTargetPosition(Vector2 direction)
    {
        float moveFraction = Mathf.Clamp01(Vector3.Distance(MouseScreenPosition(), _cameraPosition) / Screen.width);
        Vector2 position = _startPosition + direction * _maxMoveRadius * moveFraction;

        if (Vector2.Distance(_startPosition, _targetPosition) > _maxMoveRadius)
        {
            return _startPosition + (direction.normalized * _maxMoveRadius);
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

    private bool IsMove()
    {
        return _input.PlayerActionMap.Move.ReadValue<Vector2>() != Vector2.zero;
    }
}
using UnityEngine;

public class PlayerControlParameters : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;

    private InputActionControls _input;

    private void Awake()
    {
        _input = new InputActionControls();

        _input.Enable();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    public float GetInputShoot()
    {
        return _input.PlayerActionMap.Shoot.ReadValue<float>();
    }

    public Vector2 GetMoveDirection()
    {
        return _input.PlayerActionMap.Move.ReadValue<Vector2>();
    }

    public Vector2 GetDirectionToMouse()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return (mousePosition - _rigidbody.position).normalized;
    }
}
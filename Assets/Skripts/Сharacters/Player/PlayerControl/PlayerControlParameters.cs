using UnityEngine;

public class PlayerControlParameters : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] private InputControlSystem _controlSystem;

    private InputActionControls _input;

    private void Start()
    {
        _input = _controlSystem.Input;

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
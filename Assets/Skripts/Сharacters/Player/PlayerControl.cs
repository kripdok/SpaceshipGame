using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private PlayerControlParameters _parameters;
    [SerializeField] private ShootingSystem _shootingSystem;
    [SerializeField] private MovementSystem _movementSystem;
    [SerializeField] private RotationSystem _rotationSystem;

    private void FixedUpdate()
    {
        _movementSystem.Move(_parameters.GetMoveDirection());
    }

    void Update()
    {
        Vector2 directionToMause = _parameters.GetDirectionToMouse();

        _shootingSystem.Shoot(_parameters.GetInputShoot(), directionToMause, transform.position);
        _rotationSystem.Rotate(directionToMause);
    }
}
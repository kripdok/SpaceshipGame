using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementSystem : MonoBehaviour
{
    [SerializeField] private PlayerSkills _skills;
    [SerializeField] private PlayerEffects _effects;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private MoveSourceController _moveSourseController;

    private Vector2 _direction;

    private float _brakingSpeed = 2f;
    private float _speedAcceleration => _skills.Speed;

    public event UnityAction<bool> PlayerMoved;

    public void Move(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            PlayEffect();
            _direction = SetMoveDirection(direction);
            AddForce(_speedAcceleration);
        }
        else
        {
            StopEffect();
            _direction = SetStopDirection();
            AddForce(_brakingSpeed);
        }
    }

    private void PlayEffect()
    {
        _effects.EngineEffect.Play();
        PlayerMoved?.Invoke(true);
    }

    private Vector2 SetMoveDirection(Vector2 _direction)
    {
        Vector2 horizontalDirection = new Vector2(_rigidbody.transform.right.x, _rigidbody.transform.right.y).normalized * _direction.y;
        Vector2 verticalDirection = -(_rigidbody.transform.up) * _direction.x;
        return horizontalDirection + verticalDirection;
    }

    private void StopEffect()
    {
        _effects.EngineEffect.Stop();
        PlayerMoved?.Invoke(false);
    }

    private void AddForce(float _spead)
    {
        _rigidbody.AddForce(_direction * _spead);
    }

    private Vector2 SetStopDirection()
    {
        return -_rigidbody.velocity;
    } 
}
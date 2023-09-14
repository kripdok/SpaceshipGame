using UnityEngine;
using UnityEngine.Events;

public class MovementSystem : MonoBehaviour
{
    [SerializeField] private PlayerSkills _skills;
    [SerializeField] private PlayerEffects _effects;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private MoveSourceController _moveSourseController;

    private float _brakingSpeed = 2f;
    private float _speedAcceleration => _skills.Speed;

    public event UnityAction<bool> PlayerMoved;

    public void Move(Vector2 _direction)
    {
        if (_direction != Vector2.zero)
        {
            _effects.EngineEffect.Play();
            PlayerMoved?.Invoke(true);

            Vector2 horizontalDirection = new Vector2(_rigidbody.transform.right.x, _rigidbody.transform.right.y).normalized * _direction.y;

            Vector2 verticalDirection = -(_rigidbody.transform.up) * _direction.x;
            Vector2 direction = horizontalDirection + verticalDirection;
            
            _rigidbody.AddForce(direction * _speedAcceleration);
        }
        else
        {
            Stop();
        }
    }

    private void Stop()
    {
        _effects.EngineEffect.Stop();
        PlayerMoved?.Invoke(false);
        Vector2 stoppingForce = -_rigidbody.velocity * _brakingSpeed;
        _rigidbody.AddForce(stoppingForce);
    }
}
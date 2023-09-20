using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Asteroid : Enemy
{
    [Header("Spead")]
    [SerializeField] protected float MaxSpeedRotation = 4;
    [SerializeField] protected float MinSpeed;
    [SerializeField] protected float MaxSpeed;
    [Space(5)]
    [Header("Scale")]
    [SerializeField] protected float MinScale;
    [SerializeField] protected float MaxScale;
    [Space(5)]

    private Rigidbody2D _rigidbody;
    private float _speed;
    private float _rotationSpeed;

    protected void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        transform.localScale = EnemyRandomizer.SetScale(MinScale, MaxScale);
        _rotationSpeed = EnemyRandomizer.SetFloat(-MaxSpeedRotation, MaxSpeedRotation);
        _speed = EnemyRandomizer.SetFloat(MinSpeed, MaxSpeed);
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    public override void Move(Vector2 moveDirection)
    {

        _rigidbody.AddForce(moveDirection * _speed, ForceMode2D.Impulse);
    }

    private void Rotate() 
    {
        _rigidbody.rotation += _rotationSpeed;
    }
}
using UnityEngine;

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


    private float _rotationSpeed;

    protected void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        HealthSystem = GetComponent<HealthSystem>();

        transform.localScale = EnemyRandomizer.SetScale(MinScale, MaxScale);
        _rotationSpeed = EnemyRandomizer.SetFloat(-MaxSpeedRotation, MaxSpeedRotation);
        Speed = EnemyRandomizer.SetFloat(MinSpeed, MaxSpeed);
    }

    private void OnEnable()
    {
        HealthSystem.Died += Die;
    }

    private void OnDisable()
    {
        HealthSystem.Died -= Die;
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    public override void Move(Vector2 moveDirection)
    {

        RigidBody.AddForce(moveDirection * Speed, ForceMode2D.Impulse);
    }

    private void Rotate() // А если я хочу сделать класс который тоже крутиться, но не является астеройдом. Возможно бредовая идея, но может тоже выделить отдельный интерфейс
        // Скорее всего сдесь я перегибаю палку.
    {
        RigidBody.rotation += _rotationSpeed;
    }
}
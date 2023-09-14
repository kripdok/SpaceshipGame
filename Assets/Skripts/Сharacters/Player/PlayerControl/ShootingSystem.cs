using UnityEngine;

public class ShootingSystem : MonoBehaviour 
{
    [SerializeField] private PlayerSound _sound;
    [SerializeField] private PlayerSkills _skills;

    private float _lastShootTime;
    private Bullet _bullet =>_skills.Bullet;
    private float _shootDelay => _skills.ShootDelay;

    private void Awake()
    {
        _lastShootTime = 0;
    }

    public void Shoot(float inputShoot, Vector2 directionToMouse, Vector3 position )
    {
        _lastShootTime -= Time.deltaTime;

        if (_lastShootTime <= 0 && inputShoot != 0)
        {
            _sound.PlaySound(_sound.Shoot);
            Bullet bullet = Instantiate(_bullet, position, Quaternion.identity);
            bullet.Fire(directionToMouse);
            _lastShootTime = _shootDelay;
        }
    }
}
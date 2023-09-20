using UnityEngine;

public class PlayerShootingSystem : MonoBehaviour 
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
            bullet.Move(directionToMouse);
            _lastShootTime = _shootDelay;
        }
    }
}
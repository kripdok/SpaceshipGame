using UnityEngine;

public class RotationSystem : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    public void Rotate(Vector2 directionToMouse)
    {
        float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
        _rigidbody.rotation = angle;
    }
}

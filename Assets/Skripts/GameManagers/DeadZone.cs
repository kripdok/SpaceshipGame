using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DeadZone : MonoBehaviour
{
    [SerializeField] private float _widthMargin = 1f;
    [SerializeField] private float _heightMargin = 1f;

    private BoxCollider2D _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        AdjustSize();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    private void AdjustSize() // Название менять
    {
        if (_collider != null && Camera.main != null)
        {
            float camHeight = 2f * Camera.main.orthographicSize;
            float camWidth = camHeight * Camera.main.aspect;

            _collider.size = new Vector2(camWidth + _widthMargin, camHeight + _heightMargin);
        }
    }
}

using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private TargetPoint[] _points;
    private Transform _currentPoint;
    private int _currentIndex;
    private float _speed = 2f;

    private void Start()
    {
        _currentPoint = _points[0].transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentPoint.position, _speed * Time.deltaTime); // Сделать отдельный метод

        if (Vector3.Distance(transform.position, _currentPoint.position) < 0.1f)
        {
            _currentIndex++;

            if (_currentIndex >= _points.Length)
            {
                _currentIndex = 0;
            }

            _currentPoint = _points[_currentIndex].transform;
        }
    }
}

using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private TargetPoint[] _points;

    private Transform _currentPoint;
    private int _currentIndex;
    private float _speed = 2f;

    private void Awake()
    {
        _currentIndex = 0;
        _currentPoint = _points[_currentIndex].transform;
    }

    private void Update()
    {
        Move();
        TryChangePoint();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentPoint.position, _speed * Time.deltaTime);
    }

    private void TryChangePoint()
    {
        if (Vector3.Distance(transform.position, _currentPoint.position) < 0.1f)
        {
            int index = GetIndex();
            _currentPoint = _points[index].transform;
        }
    }

    private int GetIndex()
    {
        _currentIndex++;

        if (_currentIndex >= _points.Length)
        {
            _currentIndex = 0;
        }

        return _currentIndex;
    }
}
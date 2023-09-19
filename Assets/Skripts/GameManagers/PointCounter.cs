using UnityEngine;
using UnityEngine.Events;

public class PointCounter : MonoBehaviour
{
    [SerializeField] private PointCounterUI _pointCounterUI;
    [SerializeField] private int _targetNumber = 50;

    private int _correctPoint;

    public int CorrectPoint => _correctPoint;

    public event UnityAction MilestoneReached;

    public void Awake()
    {
        _correctPoint = 0;
        _pointCounterUI.DisplayPointsOnScreen(_correctPoint);
    }

    private void OnEnable()
    {
        Enemy.PassPoint += AddPoints;
    }

    private void OnDisable()
    {
        Enemy.PassPoint -= AddPoints;
    }

    private void AddPoints(int points)
    {
        _correctPoint += points;
        TryChangeTargetPoint();
        _pointCounterUI.DisplayPointsOnScreen(_correctPoint);
    }

    private void TryChangeTargetPoint()
    {
        if (_correctPoint >= _targetNumber)
        {
            MilestoneReached?.Invoke();
            _targetNumber *= 2;
        }
    }
}
using UnityEngine;
using UnityEngine.Events;

public class PointCounter : MonoBehaviour
{
    [SerializeField] private PointCounterUI _pointCounterUI;
    [SerializeField] private int _targetNumber = 50;
    public int CorrectPoint { get; private set; }

    public event UnityAction MilestoneReached;

    public void Awake()
    {
        CorrectPoint = 0;
        _pointCounterUI.ChangeValue(CorrectPoint, _targetNumber);
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
        CorrectPoint += points;

        if (CorrectPoint >= _targetNumber)
        {
            ChangeTargetPoint();
        }

        _pointCounterUI.ChangeValue(CorrectPoint, _targetNumber);
    }

    private void ChangeTargetPoint()
    {

        MilestoneReached?.Invoke();
        _targetNumber *= 2;

    }
}

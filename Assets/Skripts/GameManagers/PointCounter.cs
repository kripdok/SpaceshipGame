using UnityEngine.Events;

public class PointCounter
{
    private PointCounterUI _pointCounterUI;
    private int _targetNumber;
    public int CorrectPoint { get; private set; }

    public event UnityAction MilestoneReached;

    public PointCounter(PointCounterUI pointCounterUI, int targetNumber)
    {
        CorrectPoint = 0;
        _targetNumber = targetNumber;
        _pointCounterUI = pointCounterUI;
        _pointCounterUI.ChangeValue(CorrectPoint, _targetNumber);
    }

    public void AddPoints(int points)
    {
        CorrectPoint += points;
       
        if (CorrectPoint >= _targetNumber)
        {
            MilestoneReached?.Invoke();
            _targetNumber *= 2;
        }

        _pointCounterUI.ChangeValue(CorrectPoint, _targetNumber);
    }
}

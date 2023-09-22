using System;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private TimerUI _timerUI;
    [SerializeField] private float _targetTime = 30;

    private float _correñtTime;

    public event UnityAction MilestoneReached;

    private void Awake()
    {
        _correñtTime = 0;
    }

    private void Update()
    {
        ChangeTimerValue();

        if (_correñtTime >= _targetTime)
        {
            ChangeTargetTime();
        }
    }

    private void ChangeTimerValue()
    {
        _correñtTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(_correñtTime);
        _timerUI.DisplayVolumeOnScreen(time);
    }

    private void ChangeTargetTime()
    {
        MilestoneReached?.Invoke();
        _targetTime += _targetTime;
    }
}
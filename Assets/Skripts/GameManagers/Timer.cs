using System;
using UnityEngine;
using UnityEngine.Events;

public class Timer
{
    private TimerUI _timerUI;
    private float _correñtTime;
    private float _targetTime;

    public event UnityAction MilestoneReached;

    public Timer(TimerUI timerUI, float targetTime)
    {
        _correñtTime = 0;
        _timerUI = timerUI;
        _targetTime = targetTime;
    }

    public void Update()
    {
        _correñtTime += Time.deltaTime; // Îòäåëüíûé ìåòîä
        TimeSpan time = TimeSpan.FromSeconds(_correñtTime);
        _timerUI.ChangeValue(time);
        

        if (_correñtTime >= _targetTime)
        {
            MilestoneReached?.Invoke();
            _targetTime += _targetTime;
        }
    }
}
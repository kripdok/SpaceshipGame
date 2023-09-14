using System;
using UnityEngine;
using UnityEngine.Events;

public class Timer
{
    private TimerUI _timerUI;
    private float _corre�tTime;
    private float _targetTime;

    public event UnityAction MilestoneReached;

    public Timer(TimerUI timerUI, float targetTime)
    {
        _corre�tTime = 0;
        _timerUI = timerUI;
        _targetTime = targetTime;
    }

    public void Update()
    {
        _corre�tTime += Time.deltaTime; // ��������� �����
        TimeSpan time = TimeSpan.FromSeconds(_corre�tTime);
        _timerUI.ChangeValue(time);
        

        if (_corre�tTime >= _targetTime)
        {
            MilestoneReached?.Invoke();
            _targetTime += _targetTime;
        }
    }
}
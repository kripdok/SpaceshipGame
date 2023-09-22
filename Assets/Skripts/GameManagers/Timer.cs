using System;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private TimerUI _timerUI;
    [SerializeField] private float _targetTime = 30;

    private float _corre�tTime;

    public event UnityAction MilestoneReached;

    private void Awake()
    {
        _corre�tTime = 0;
    }

    private void Update()
    {
        ChangeTimerValue();

        if (_corre�tTime >= _targetTime)
        {
            ChangeTargetTime();
        }
    }

    private void ChangeTimerValue()
    {
        _corre�tTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(_corre�tTime);
        _timerUI.DisplayVolumeOnScreen(time);
    }

    private void ChangeTargetTime()
    {
        MilestoneReached?.Invoke();
        _targetTime += _targetTime;
    }
}
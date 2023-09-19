using System;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void DisplayTimeOnScreen(TimeSpan time)
    {
        _text.text = string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);
    }
}
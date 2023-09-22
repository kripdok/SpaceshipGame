using TMPro;
using UnityEngine;

public class DeadWindow : Panel, IUIDisplay<int>
{
    [SerializeField] private TMP_Text _score;

    public void DisplayVolumeOnScreen(int value)
    {
        _score.text = value.ToString();
    }
}

using TMPro;
using UnityEngine;

public class PlayerHealthCounterUI : MonoBehaviour , IUIDisplay<int>
{
    [SerializeField] private TMP_Text _text;

    public void DisplayVolumeOnScreen(int value)
    {
        _text.text = "X" + value;
    }
}
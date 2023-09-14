using TMPro;
using UnityEngine;

public class PlayerHealthCounterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void ChangeValue(int number) // ����� value?
    {
        _text.text = "X" + number;
    }
}
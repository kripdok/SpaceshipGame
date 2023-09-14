using TMPro;
using UnityEngine;

public class PointCounterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void ChangeValue(int number, int targetNumber) // какое value?
    {
        _text.text = number + "/" + targetNumber;
    }
}
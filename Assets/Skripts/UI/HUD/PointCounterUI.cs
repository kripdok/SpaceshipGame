using TMPro;
using UnityEngine;

public class PointCounterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void DisplayPointsOnScreen(int points)
    {
        _text.text = points.ToString();
    }
}
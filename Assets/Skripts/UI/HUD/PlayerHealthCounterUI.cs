using TMPro;
using UnityEngine;

public class PlayerHealthCounterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void DisplayHealthOnScreen(int health)
    {
        _text.text = "X" + health;
    }
}
using TMPro;
using UnityEngine;

public class DeadWindow : Panel
{
    [SerializeField] private TMP_Text _score;

    public void SetScore(int score) // ������ ��������
    {
        _score.text = score.ToString();
    }
}

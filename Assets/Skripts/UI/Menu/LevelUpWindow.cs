using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpWindow : MonoBehaviour
{
    [SerializeField] private PlayerSkills _skills;
    [SerializeField] private TMP_Text _pointNumber;
    [SerializeField] private List<AbilityIcon> _icons;
    [SerializeField] private Button _levelUpButton;

    private void Awake()
    {
        AddPlayerSkillsToAbilityIcons();
    }

    private void OnEnable()
    {
        TryActivateIcons();
    }

    public void DisplayPointsOnWindow(int skillPoint)
    {
        _pointNumber.text = "X" + skillPoint;
    }

    public void TryTurnOffAllAbilityIcon(int skillPoint)
    {
        if (skillPoint == 0)
        {
            foreach (AbilityIcon icon in _icons)
            {
                icon.ChangeActivationMode(false);
            }
        }
    }

    private void AddPlayerSkillsToAbilityIcons()
    {
        foreach (var icon in _icons)
        {
            icon.AddPlayerSkills(_skills);
        }
    }

    private void TryActivateIcons()
    {
        foreach (AbilityIcon icon in _icons)
        {
            if (icon.LimitIsReached == false)
            {
                icon.ChangeActivationMode(true);
            }
        }
    }
}
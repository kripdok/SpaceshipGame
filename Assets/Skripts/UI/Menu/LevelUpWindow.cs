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

    private void OnEnable()
    {
        if (_skills.SkillPoint > 0)
        {
            foreach (AbilityIcon icon in _icons)
            {
                if (icon.IsFull == false)
                {
                    icon.OperateButton(true);
                }
            }
        }
    }

    private void Update()
    {
        _pointNumber.text = "X" + _skills.SkillPoint.ToString(); //сделать метод и вынести из обновления

        if(_skills.SkillPoint == 0)
        {
            foreach(AbilityIcon icon in  _icons)
            {
                icon.OperateButton(false);
            }

            _levelUpButton.gameObject.SetActive(false);
        }
    }
}
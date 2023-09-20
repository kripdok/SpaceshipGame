using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIcon : MonoBehaviour
{
    [SerializeField] private Ability _ability;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _name;

    private PlayerSkills _playerSkills;

    public bool LimitIsReached => _ability.IsMaxNumber;

    private void Start()
    {
        _name.text = _ability.Name;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ApplyAbility);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ApplyAbility);
    }

    public void ChangeActivationMode(bool state)
    {
        _button.interactable= state;
    }

    public void AddPlayerSkills(PlayerSkills skills)
    {
        _playerSkills = skills;
    }

    private void TryEnableButton()
    {
        if (LimitIsReached)
        {
            _button.interactable = false;
        }
    }

    private void ApplyAbility()
    {
        _ability.ImproveSkill(_playerSkills);
        TryEnableButton();
    }
}
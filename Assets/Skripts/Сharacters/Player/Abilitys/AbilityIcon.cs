using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIcon : MonoBehaviour
{
    [SerializeField] private Ability _ability;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _name;

    public bool IsFull => _ability.IsMaxNumber;

    private void Start()
    {
        _name.text = _ability.Name;
    }

    private void Update()
    {
        if (IsFull)
        {
            _button.interactable= false;
        }
    }

    public void OperateButton(bool state)
    {
        _button.interactable= state;
    }
}
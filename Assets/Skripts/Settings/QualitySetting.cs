using TMPro;
using UnityEngine;

public class QualitySetting : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;


    private void OnEnable()
    {
        _dropdown.onValueChanged.AddListener(ChangeGraphicSettings);
    }

    private void OnDisable()
    {
        _dropdown.onValueChanged.RemoveListener(ChangeGraphicSettings);
    }

    private void ChangeGraphicSettings(int value)
    {
        QualitySettings.SetQualityLevel(value);
    }
}
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResolutionSetting : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;

    private Resolution[] resolutions;
    private int _indexConcreteResolution;

    private void Awake()
    {
        resolutions = Screen.resolutions;
        _dropdown.ClearOptions();
        AddResolutionToDropdown();
    }

    private void OnEnable()
    {
        _dropdown.onValueChanged.AddListener(ChangeResolurion);
    }

    private void OnDisable()
    {
        _dropdown.onValueChanged.RemoveListener(ChangeResolurion);
    }

    private void AddResolutionToDropdown()
    {
        List<string> oprions = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string oprion = resolutions[i].width + " x " + resolutions[i].height;
            oprions.Add(oprion);
            TrySetCorrectDropdownValue(i);
        }

        _dropdown.AddOptions(oprions);
    }

    private void TrySetCorrectDropdownValue(int index)
    {
        if (resolutions[index].width == Screen.currentResolution.width && resolutions[index].height == Screen.currentResolution.height)
        {
            _dropdown.value = _indexConcreteResolution;
            _dropdown.RefreshShownValue();
        }
    }

    private void ChangeResolurion(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
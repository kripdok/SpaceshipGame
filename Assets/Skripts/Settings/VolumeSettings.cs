using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixerGroup;
    [SerializeField] private Slider _musicVolume;
    [SerializeField] private Slider _effectVolume;

    private int _defoltVolume = 1;
    private MixerName _mixerName;

    private void Start()
    {
        _mixerName = new MixerName();
        TryLoadVolume();
    }

    private void OnEnable()
    {
        _musicVolume.onValueChanged.AddListener(SetMusicVolume);
        _effectVolume.onValueChanged.AddListener(SetEffectsVolume);
    }

    private void OnDisable()
    {
        _musicVolume.onValueChanged.RemoveListener(SetMusicVolume);
        _effectVolume.onValueChanged.RemoveListener(SetEffectsVolume);
    }

    private void TryLoadVolume()
    {
        if (PlayerPrefs.HasKey(_mixerName.Music))
        {
            LoadMusicVolume();
        }
        else
        {
            SetMusicVolume(_defoltVolume);
        }

        if (PlayerPrefs.HasKey(_mixerName.Effects))
        {
            LoadEffectsVolume();
        }
        else
        {
            SetEffectsVolume(_defoltVolume);
        }
    }

    private void SetMusicVolume(float volume)
    {
        SetValue(_mixerName.Music, volume);
        PlayerPrefs.SetFloat(_mixerName.Music, volume);
    }

    private void SetEffectsVolume(float volume)
    {
        SetValue(_mixerName.Effects, volume);
        PlayerPrefs.SetFloat(_mixerName.Effects, volume);
    }

    private void SetValue(string valueName, float volume)
    {
        _audioMixerGroup.SetFloat(valueName, Mathf.Log10(volume) * 20f);
    }

    private void LoadMusicVolume()
    {
        _musicVolume.value = PlayerPrefs.GetFloat(_mixerName.Music);
        SetMusicVolume(_musicVolume.value);
    }

    private void LoadEffectsVolume()
    {
        _effectVolume.value = PlayerPrefs.GetFloat(_mixerName.Effects);
        SetEffectsVolume(_effectVolume.value);
    }
}
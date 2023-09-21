using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixerGroup;
    [SerializeField] private Slider _musicVolume;
    [SerializeField] private Slider _effectVolume;

    private MixerVolume _mixerVolume;

    private void Start()
    {
        _mixerVolume = new MixerVolume();

        if (PlayerPrefs.HasKey(_mixerVolume.Music))
        {
            LoadMusicVolume();
        }
        else
        {
            SetMusicVolume(1);
        }

        if (PlayerPrefs.HasKey(_mixerVolume.Effects))
        {
            LoadEffectsVolume();
        }
        else
        {
            SetEffectsVolume(1);
        }
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


    private void SetMusicVolume(float volume)
    {
        SetValue(_mixerVolume.Music, volume);
        PlayerPrefs.SetFloat(_mixerVolume.Music, volume);
    }

    private void SetEffectsVolume(float volume)
    {
        SetValue(_mixerVolume.Effects, volume);
        PlayerPrefs.SetFloat(_mixerVolume.Effects, volume);
    }

    private void SetValue(string valueName, float volume)
    {
        _audioMixerGroup.SetFloat(valueName, Mathf.Log10(volume) * 20f);
    }

    private void LoadMusicVolume()
    {
        _musicVolume.value = PlayerPrefs.GetFloat(_mixerVolume.Music);
        SetMusicVolume(_musicVolume.value);
    }

    private void LoadEffectsVolume()
    {
        _effectVolume.value = PlayerPrefs.GetFloat(_mixerVolume.Effects);
        SetEffectsVolume(_effectVolume.value);
    }
}
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixerGroup;
    [SerializeField] private Slider _musicVolume;
    [SerializeField] private Slider _effectVolume;

    private MixerVolume _mixerVolume;

    private void Start()
    {
        _mixerVolume = new MixerVolume();
    }

    private void OnEnable()
    {
        _musicVolume.onValueChanged.AddListener(SetMusicVolume);
        _effectVolume.onValueChanged.AddListener(SetEffectVolume);
    }

    private void OnDisable()
    {
        _musicVolume.onValueChanged.RemoveListener(SetMusicVolume);
        _effectVolume.onValueChanged.RemoveListener(SetEffectVolume);
    }


    private void SetMusicVolume(float volume) // ну хз, надо подумать над этой системой.
    {
        SetValue(_mixerVolume.Music, volume);
    }

    private void SetEffectVolume(float volume)
    {
        SetValue(_mixerVolume.Effects,volume);
    }

    private void SetValue(string valueName, float volume)
    {
        _audioMixerGroup.SetFloat(valueName, Mathf.Log10(volume) *20);
    }
}

using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioClip _musicClip;
    [SerializeField] private AudioClip _stopMusicClip;

    private AudioSource _music;

    private void Awake()
    {
        _music = GetComponent<AudioSource>();
        _music.clip = _musicClip;
        _music.loop = true;
        _music.Play();
    }

    public void PlayTheStopMusicClip()
    {
        _music.Stop();
        _music.clip = _stopMusicClip;
        _music.loop = false;
        _music.Play();
    }
}
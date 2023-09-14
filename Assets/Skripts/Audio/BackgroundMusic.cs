using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioClip _musicClip;
    [SerializeField] private AudioClip _stopMusicClip;

    private void Awake()
    {
        _music = GetComponent<AudioSource>();
        _music.clip = _musicClip;
        _music.loop = true;
        _music.Play();
    }

    private void OnEnable()
    {
        _gameManager.GameIsOver += StopMusic;
    }

    private void OnDisable()
    {
        _gameManager.GameIsOver -= StopMusic;
    }

    private void StopMusic()
    {
        _music.Stop();
        _music.clip = _stopMusicClip;
        _music.loop = false;
        _music.Play();
    }
}
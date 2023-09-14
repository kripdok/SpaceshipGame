using UnityEngine;

public class Music : Sound
{
    [SerializeField] private AudioClip _backgroundMusic;

    public AudioClip BackgroundMusic => _backgroundMusic;

    public override void PlaySound(AudioClip clip)
    {
        AudioSource.PlayOneShot(clip);
    }
}
using UnityEngine;

public class ShieldSound : Sound
{
    [SerializeField] private AudioClip _shieldActivate;
    [SerializeField] private AudioClip _shieldDeactivate;

    public AudioClip ShieldDeactivate => _shieldDeactivate;
    public AudioClip ShieldActivate => _shieldActivate;

    public override void PlaySound(AudioClip clip)
    {
        AudioSource.PlayOneShot(clip);
    }
}
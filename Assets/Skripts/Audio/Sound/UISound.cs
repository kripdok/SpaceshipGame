using UnityEngine;

public class UISound : Sound
{
    [SerializeField] private AudioClip _playerDead;
    [SerializeField] private AudioClip _addSkillPoint;

    public AudioClip PlayerDead => _playerDead;
    public AudioClip AddSkillPoint => _addSkillPoint;

    public override void PlaySound(AudioClip clip)
    {
        AudioSource.PlayOneShot(clip);
    }
}

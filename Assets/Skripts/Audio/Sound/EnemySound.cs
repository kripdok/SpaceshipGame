using UnityEngine;

public class EnemySound : Sound
{
    [SerializeField] private AudioClip _dead;

    public AudioClip Dead => _dead;

    public override void PlaySound(AudioClip clip)
    {
        AudioSource.PlayOneShot(clip);
    }
}

using UnityEngine;

public class PlayerSound : Sound
{
    [SerializeField] private AudioClip _shoot;
    [SerializeField] private AudioClip _dead;
    [SerializeField] private AudioClip _collision;
    [SerializeField] private AudioClip _pickUpHeal;
    [SerializeField] private AudioClip _shieldCollision;


    public AudioClip Shoot => _shoot;
    public AudioClip Dead => _dead;
    public AudioClip Collision => _collision;
    public AudioClip ShieldCollision => _shieldCollision;
    public AudioClip PickUpHeal => _pickUpHeal;

    public override void PlaySound(AudioClip clip)
    {
        AudioSource.PlayOneShot(clip);
    }
}
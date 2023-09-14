using UnityEngine;

public abstract class Sound : MonoBehaviour
{
    [SerializeField] protected AudioSource AudioSource;
    public abstract void PlaySound(AudioClip clip);
}
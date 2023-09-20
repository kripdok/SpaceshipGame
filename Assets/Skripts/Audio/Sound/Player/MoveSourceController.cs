using System.Collections;
using UnityEngine;

public class MoveSourceController: MonoBehaviour
{
    [SerializeField] private PlayerMovementSystem _movementSystem;
    [SerializeField] private AudioSource _MoveSourse;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private float speed = 0.2f;

    private Coroutine _fadeCoroutine;

    private void Awake()
    {
        _MoveSourse.clip = _clip;
        _MoveSourse.loop = true;
        _MoveSourse.playOnAwake = false;
        _MoveSourse.volume = 0;
    }

    private void OnEnable()
    {
        _movementSystem.PlayerMoved += Play;
    }

    private void OnDisable()
    {
        _movementSystem.PlayerMoved -= Play;
    }

    public void Play(bool isMoving)
    {
        if (_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
        }

        if (isMoving)
        {
            if (!_MoveSourse.isPlaying)
            {
                _MoveSourse.Play();
            }

            _fadeCoroutine = StartCoroutine(FadeIn());
        }
        else
        {
            _fadeCoroutine = StartCoroutine(FadeOut());
        }
    }


    private IEnumerator FadeIn()
    {
        while (_MoveSourse.volume < 1.0f)
        {
            _MoveSourse.volume += Mathf.Lerp(0, 1, speed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        while (_MoveSourse.volume > 0.01f)
        {
            _MoveSourse.volume = Mathf.Lerp(_MoveSourse.volume, 0, Time.deltaTime);
            yield return null;
        }

        _MoveSourse.volume = 0;
        _MoveSourse.Stop();
    }
}

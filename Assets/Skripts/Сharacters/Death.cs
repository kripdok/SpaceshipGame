using System.Collections;
using UnityEngine;

public abstract class Death : MonoBehaviour
{
    protected abstract void RunDeathEffectsCoroutine();

    protected abstract IEnumerator PlayTheDeathEffects();
}
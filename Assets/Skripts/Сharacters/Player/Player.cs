using UnityEngine;

[RequireComponent(typeof(PlayerHealthSystem))]
[RequireComponent(typeof(PlayerSkills))]
[RequireComponent(typeof(StayInside))]

public class Player : MonoBehaviour
{
    [HideInInspector]public bool IsShieldActive;

    private PlayerShield _shield;

    private void Awake()
    {
        _shield = GetComponent<PlayerShield>();
    }

    private void OnEnable()
    {
        _shield.Works += UpdateShieldStatus;
    }

    private void OnDisable()
    {
        _shield.Works -= UpdateShieldStatus;
    }

    private void UpdateShieldStatus(bool shieldStatus)
    {
        IsShieldActive = shieldStatus;
    }
}
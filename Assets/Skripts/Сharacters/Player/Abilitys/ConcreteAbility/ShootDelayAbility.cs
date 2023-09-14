using UnityEngine;

public class ShootDelayAbility : Ability
{
    [SerializeField] private float _delay = 0.1f;

    private string _name = "Add the Shoot Delay";

    private void Awake()
    {
        Name = _name;
    }

    public override void Apply(PlayerSkills skills)
    {
        ConcreteNumber++;
        skills.IncreaseShootDelay(_delay);
    }
}
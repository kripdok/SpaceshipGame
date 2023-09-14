using UnityEngine;

public class ShieldRuntimeAbility : Ability
{
    [SerializeField] private float _runtime = 0.2f;

    private string _name = "Add the Shield Runtime";

    private void Awake()
    {
        Name = _name;
    }

    public override void Apply(PlayerSkills skills)
    {
        ConcreteNumber++;
        skills.IncreaseShieldRuntime(_runtime);
    }
}
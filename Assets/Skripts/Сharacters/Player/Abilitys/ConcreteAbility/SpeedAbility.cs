using UnityEngine;

public class SpeedAbility : Ability
{
    [SerializeField] private float _speed = 0.5f;

    private string _name = "Add the Speed Acceleration";

    private void Awake()
    {
        Name = _name;
    }

    public override void ImproveSkill(PlayerSkills skills)
    {
        ConcreteNumber++;
        skills.IncreaseSpeed(_speed);
    }
}
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private int _maxNumberImprovements;

    protected int ConcreteNumber;
    public string Name { get; protected set; }

    public bool IsMaxNumber => ConcreteNumber == _maxNumberImprovements;


    private void Start()
    {
        ConcreteNumber = 0;
    }

    public abstract void ImproveSkill(PlayerSkills skills);
}
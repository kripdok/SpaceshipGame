using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] private int _maxNumberImprovements;

    protected int ConcreteNumber;

    public bool IsMaxNumber => ConcreteNumber == _maxNumberImprovements;
    public string Name { get; protected set; }

    private void Start()
    {
        ConcreteNumber = 0;
    }

    public abstract void Apply(PlayerSkills skills);
}
using UnityEngine;

[RequireComponent(typeof(Division))]
public class BigAsteroid : Asteroid
{
    private Division _division;

    private void Start()
    {
        _division = GetComponent<Division>();
    }

    protected override void Destroy()
    {
        _division.Split();
        base.Destroy();
    }    
}
using System.Collections.Generic;
using UnityEngine;

public class BigAsteroid : Asteroid
{
    [Header("Variables for split")]
    [SerializeField] private Asteroid _asteroid;
    [SerializeField] private int _numberOfSplits = 2;
    [SerializeField] private float _splitSpeed = 5f;

    protected override void Die()
    {
        base.Die();
        Split();
    }

    private void Split()
    {
        List<float> usedAngles = new List<float>();

        for (int i = 0; i < _numberOfSplits; i++)
        {
            float angle;

            do
            {
                angle = Random.Range(0f, 360f);
            }
            while (IsAngleTooClose(usedAngles, angle));

            usedAngles.Add(angle);

            angle *= Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;

            Vector2 spawnPosition = transform.position + (Vector3)direction * 1.5f;
            Asteroid newAsteroid = Instantiate(_asteroid, spawnPosition, Quaternion.identity);
            newAsteroid.Move(direction * _splitSpeed);
        }
    }

    bool IsAngleTooClose(List<float> angles, float targetAngle, float minDifference = 20f) // јстеройд не должен просчитывать, может он создать его обломки под нужным углом или нет
        // —хему по€влени€ новых астеройдов надо переделать в другой класс.
    {
        foreach (float angle in angles)
        {
            if (Mathf.Abs(angle - targetAngle) < minDifference)
            {
                return true;
            }
        }

        return false;
    }
}
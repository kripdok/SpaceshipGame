using System.Collections.Generic;
using UnityEngine;

public class Division : MonoBehaviour
{
    [SerializeField] private Asteroid _asteroid;
    [SerializeField] private int _numberOfSplits = 2;

    public void Split()
    {
        List<float> angles = new List<float>();

        for (int i = 0; i < _numberOfSplits; i++)
        {
            float angle = SetAngleDirection(angles);
            Vector2 direction = SetDirection(angle);
            Vector2 spawnPosition = SetSpawnPosition(direction);
            InstantiateNewAsteroid(spawnPosition, direction);
        }
    }

    private float SetAngleDirection(List<float> angles)
    {
        float angle;

        do
        {
            angle = Random.Range(0f, 360f);
        }
        while (IsAngleTooClose(angles, angle));

        angles.Add(angle);
        return angle * Mathf.Deg2Rad;
    }

    private bool IsAngleTooClose(List<float> angles, float targetAngle, float minDifference = 20f)
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

    private Vector2 SetDirection(float angle)
    {
       return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }

    private Vector2 SetSpawnPosition(Vector2 direction)
    {
        float parentalDistance = 1.5f;

        return transform.position + (Vector3)direction * parentalDistance;
    }

    private void InstantiateNewAsteroid(Vector2 spawnPosition, Vector2 direction)
    {
        Asteroid newAsteroid = Instantiate(_asteroid, spawnPosition, Quaternion.identity);
        newAsteroid.Move(direction);
    }
}
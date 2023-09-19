using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public void SpawnEnemy(Enemy enemy, Vector2 targetPosition)
    {
        Enemy concreteEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        targetPosition = (targetPosition - (Vector2)transform.position).normalized;
        concreteEnemy.Move(targetPosition);
    }
}
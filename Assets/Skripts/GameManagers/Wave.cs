using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave/New Wave")]
public class Wave : ScriptableObject
{
    [SerializeField] private List<Enemy> _enemys;
    [Tooltip("Time is measured in seconds")]
    [SerializeField] private float _creationTime;

    public float CreationTime => _creationTime;

    public Enemy GetEnemy()
    {
        return _enemys[Random.Range(0, _enemys.Count)];
    }
}
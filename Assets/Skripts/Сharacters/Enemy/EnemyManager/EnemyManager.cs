using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Player _target;
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private List<Wave> _waves;


    private Wave _concreteWave;
    private int _index;
    private float _taimer = 0;

    private void Start()
    {
        _index = 0;
        _concreteWave = _waves[_index];
    }

    private void OnEnable()
    {
        _gameManager.ReinforceEnemies += ImproveEnemies;
    }

    private void OnDisable()
    {
        _gameManager.ReinforceEnemies -= ImproveEnemies;
    }

    private void Update()
    {
        if (_taimer <= 0) // вывести в отдельынй метод.  Может появление врагов сделать коррутиной?
        {
            SpawnPoint concretePoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            concretePoint.SpawnEnemy(_concreteWave.GetEnemy(), _target.transform.position);
            _taimer = _concreteWave.CreationTime;
        }

        _taimer -= Time.deltaTime;
    }

    private void ImproveEnemies()
    {
        _index++;

        if (_index < _waves.Count)
        {
            _concreteWave = _waves[_index];
        }
        
    }
}
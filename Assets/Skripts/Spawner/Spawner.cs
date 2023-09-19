using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private List<Wave> _waves;

    private Wave _concreteWave;
    private int _index;
    private bool _isWork;

    private void Awake()
    {
        _index = 0;
        _isWork = true;
        _concreteWave = _waves[_index];
        StartCoroutine(SpawnEnemy());
    }

    private void OnEnable()
    {
        _timer.MilestoneReached += ChangeWave;
        _gameOver.GameFinished += StopWork;
    }

    private void OnDisable()
    {
        _timer.MilestoneReached -= ChangeWave;
        _gameOver.GameFinished -= StopWork;
    }

    private void ChangeWave()
    {
        _index++;

        if (_index < _waves.Count)
        {
            _concreteWave = _waves[_index];
        }
    }

    private void StopWork()
    {
        _isWork = false;
    }

    private IEnumerator SpawnEnemy()
    {
        SpawnPoint spawnPoint = null;
        Enemy enemy = null;

        while (_isWork)
        {
            spawnPoint = GetSpawnPoint();
            enemy = _concreteWave.GetEnemy();
            InstantiateEnemy(enemy, spawnPoint);

            yield return new WaitForSeconds(_concreteWave.CreationTime);
        }

        yield return null;
    }

    private SpawnPoint GetSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }

    private void InstantiateEnemy(Enemy enemy, SpawnPoint spawnPoint)
    {
        enemy = Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
        Vector2 corectTargetPosition = ((Vector2)_target.transform.position - (Vector2) spawnPoint.transform.position).normalized;
        enemy.Move(corectTargetPosition);
    }
}

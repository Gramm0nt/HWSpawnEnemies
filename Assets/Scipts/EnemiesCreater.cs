using System.Collections;
using UnityEngine;

public class EnemiesCreater : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject[] _spots;

    private Coroutine _spawningEnemies;
    private float _delay = 2f;
    private float _timer = 2f;

    private void Start()
    {
        StartCoroutine(EnemiesSpawnTimer());
    }

    private IEnumerator SpawningEnemies()
    {
        GameObject newEnemy =
            Instantiate(_enemy, _spots[Random.Range(0, _spots.Length)].transform.position, Quaternion.identity);
        yield return null;
    }

    private IEnumerator EnemiesSpawnTimer()
    {
        while (true)
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                if (_spawningEnemies != null)
                {
                    StopCoroutine(_spawningEnemies);
                }

                _spawningEnemies = StartCoroutine(SpawningEnemies());
                _timer = _delay;
            }

            yield return null;
        }
    }
}
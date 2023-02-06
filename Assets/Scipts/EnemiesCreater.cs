using System.Collections;
using UnityEngine;

public class EnemiesCreater : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private GameObject[] _spots;

    private WaitForSeconds _delay = new WaitForSeconds(2f);

    private void Start()
    {
        StartCoroutine(SpawningEnemies());
    }

    private IEnumerator SpawningEnemies()
    {
        while (true)
        {
            Enemy newEnemy =
                Instantiate(_enemy, _spots[Random.Range(0, _spots.Length)].transform.position, Quaternion.identity);
            yield return _delay;
        }
    }
}
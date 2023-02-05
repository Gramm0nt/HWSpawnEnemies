using System.Collections;
using UnityEngine;

public class EnemiesCreater : MonoBehaviour
{
    [SerializeField] public GameObject Enemy;
    [SerializeField] public GameObject[] Spots;

    private float _delay = 2f;

    private void Start()
    {
        StartCoroutine(CreateOneEnemy());
    }

    private IEnumerator CreateOneEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            Transform spotTransform = Spots[Random.Range(0, Spots.Length)].GetComponent<Transform>();
            GameObject newEnemy = Instantiate(Enemy, new Vector3(), Quaternion.identity);
            Transform newEnemyTransform = newEnemy.GetComponent<Transform>();
            newEnemyTransform.position = spotTransform.position;
        }
    }
}
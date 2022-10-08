using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public int _wave;
    public int _time;

    [SerializeField] private GameObject[] _easyEnemy, _mediumEnemy, _hardEnemy;

    private void Start()
    {
        StartCoroutine(Wave());
    }
    private IEnumerator Timer()
    {
        for (; _time >= 0; _time--)
        {
            HUDController.Instance.UpdateTimerText(_time);
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }
    private IEnumerator Wave()
    {
        _wave++;
        _time = _wave * 25;
        StartCoroutine(Timer());
        for (; ; )
        {
            if (_time <= 0) yield return null;

            int enemyType = Random.Range(0, 100);
            if (enemyType <= 60)
            {
                int enemysToSpawn = Random.Range(5, 30);
                for(int i = 0; i < enemysToSpawn; i++)
                {
                    SpawnEnemy(_easyEnemy[Random.Range(0, _easyEnemy.Length)]);
                    yield return new WaitForSeconds(0.05f);
                }
            }
            else if (enemyType > 60 && enemyType <= 85 && _wave > 3)
            {
                int enemysToSpawn = Random.Range(3, 15);
                for (int i = 0; i < enemysToSpawn; i++)
                {
                    SpawnEnemy(_mediumEnemy[Random.Range(0, _mediumEnemy.Length)]);
                    yield return new WaitForSeconds(0.05f);
                }
            }
            else if (enemyType > 85 && _wave > 8)
            {
                int enemysToSpawn = Random.Range(1, 5);
                for (int i = 0; i < enemysToSpawn; i++)
                {
                    SpawnEnemy(_hardEnemy[Random.Range(0, _hardEnemy.Length)]);
                    yield return new WaitForSeconds(0.05f);
                }
            }

            yield return new WaitForSeconds(10);
        }

    }
    private void SpawnEnemy(GameObject _objToSpawn)
    {
        var buffer = Instantiate(_objToSpawn);
        buffer.transform.position = new Vector3(Random.Range(-25, 25), Random.Range(-25, 25), 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    static public int _wave;
    static public int _enemyRemained;
    public int _enemySpawned;
    [SerializeField] private GameObject[] _easyEnemy, _mediumEnemy, _hardEnemy;
    private GameObject[] _buffer = new GameObject[50];
    private void Start()
    {
        StartCoroutine(Wave());
    }

    private IEnumerator Wave()
    {
        _wave++;
        int _enemysOnLvl = Random.Range(100, 150) + (int)Mathf.Sqrt(_wave);
        _enemyRemained = _enemysOnLvl;

        for(int i = 0; i < _buffer.Length; i++)
        {
            SpawnEnemy(i);
            print(_buffer[i].gameObject);
            yield return new WaitForSeconds(0.1f);
        }

        for (; _enemySpawned < _enemysOnLvl;)
        {
            for(int i = 0; i < _buffer.Length; i++)
                {
                if (_enemySpawned >= _enemysOnLvl) break;
                if (_buffer[i] == null)
                {
                    _enemyRemained--;
                    SpawnEnemy(i);
                }
            }
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }

    private void SpawnEnemy(int i)
    {
        if (_enemySpawned % 10 == 0 && _wave > 3)
        {
            _buffer[i] = Instantiate(_mediumEnemy[Random.Range(0, _mediumEnemy.Length)]);
            _buffer[i].transform.position = new Vector3(Random.Range(-25, 25), Random.Range(-25, 25), 0);
            _enemySpawned++;
        }
        else if (_enemySpawned % 25 == 0 && _wave > 8)
        {
            _buffer[i] = Instantiate(_hardEnemy[Random.Range(0, _hardEnemy.Length)]);
            _buffer[i].transform.position = new Vector3(Random.Range(-25, 25), Random.Range(-25, 25), 0);
            _enemySpawned++;
        }
        else
        {
            _buffer[i] = Instantiate(_easyEnemy[Random.Range(0, _easyEnemy.Length)]);
            _buffer[i].transform.position = new Vector3(Random.Range(-25, 25), Random.Range(-25, 25), 0);
            _enemySpawned++;
        }
    }
}

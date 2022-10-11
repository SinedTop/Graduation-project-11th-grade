using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject _objectToSpawn;
    public float _spawnDelay;

    private Animator _anim;
    private void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        _spawnDelay -= Time.deltaTime;
        if (_spawnDelay > 0.5f) _anim.speed = 2 * Mathf.Pow(_spawnDelay, -1);
        else if(_spawnDelay <= 0)
        {
            var buffer = Instantiate(_objectToSpawn);
            buffer.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
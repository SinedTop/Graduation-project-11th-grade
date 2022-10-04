using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public int _power;
    [HideInInspector] public float _maxRange;
    [HideInInspector] public float _speed;

    private Rigidbody2D _bulletRB;
    private float _range;

    private void Start()
    {
        _bulletRB = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _bulletRB.MovePosition(transform.position + _bulletRB.transform.up * Time.deltaTime * _speed);
        _range += _speed * Time.deltaTime;
        if (_range >= _maxRange) Destroy(gameObject);
    }
}

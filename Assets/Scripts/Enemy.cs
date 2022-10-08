using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public abstract class Enemy : Stats
{
    [SerializeField] private float _chooseTargetTime = 3;
    [SerializeField] protected float _stoppingDistance;

    private NavMeshAgent _agent;
    private GameObject[] _players;
    protected Transform _targetTransform;
    protected void Start()
    {
        _health = _maxHealth;
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _players = GameObject.FindGameObjectsWithTag("Player");
        _agent.speed = _speed;
        _targetTransform = _players[0].transform;
        StartCoroutine(ChooseTarget());
    }
    private void FixedUpdate()
    {
        Move();
    }
    protected void Move()
    {
        _agent.isStopped = false;
        _agent.SetDestination(_targetTransform.position);
    }
    protected void StopMove()
    {
        _agent.isStopped = true;
    }

    private IEnumerator ChooseTarget()
    {
        for(; ; )
        {
            for(int i = 0; i < _players.Length; i++)
            {
                if (Vector3.Distance(transform.position, _players[i].transform.position) <= Vector3.Distance(transform.position, _targetTransform.position)) _targetTransform = _players[i].transform;
            }
            yield return new WaitForSeconds(_chooseTargetTime);
        }
    }
}

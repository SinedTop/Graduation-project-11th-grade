using System.Collections;
using UnityEngine;

public class RangeEnemy : Enemy
{
    
    [SerializeField] private GameObject[] _weapon;
    [SerializeField] private float _range;
    private Weapon[] _weaponsScript;
    private bool _dontSee;
    private void Awake()
    {
        _weaponsScript = new Weapon[_weapon.Length];

        _stoppingDistance = _range;
        for(int i = 0; i < _weapon.Length; i++)
        {
            _weaponsScript[i] = _weapon[i].GetComponent<Weapon>();
        }
    }
    private void FixedUpdate()
    {
        if (_dontSee) Move(); 
        else StopMove(); 
    }
    private void Update()
    {
        
        if (_weapon != null) for (int i = 0; i < _weapon.Length; i++)
            {
                Vector3 moveDirection = _targetTransform.position - _weapon[i].transform.position;
                float angle = Mathf.Atan2(-moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
                _weapon[i].transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, _targetTransform.position - transform.position, _range);
        if(hit.collider == null)
        {
            _dontSee = true;
            StopShooting();
            return;
        }
        if(hit.collider.gameObject == _targetTransform.gameObject)
        {
            _dontSee = false;
            for (int i = 0; i < _weaponsScript.Length; i++) _weaponsScript[i].MakeShoot(true, "Player");
        }
        else
        {
            _dontSee = true;
            StopShooting();
        }

    }
    private void StopShooting()
    {
        if (_weaponsScript.Length != 0)
        {
            for (int i = 0; i < _weaponsScript.Length; i++) _weaponsScript[i].MakeShoot(false, "Player");
        }
    }
}

using System.Collections;
using UnityEngine;

public class RangeEnemy : Enemy
{
    [SerializeField] private GameObject[] _weapon;
    [SerializeField] private float _range;
    [SerializeField] private NonAutomaticWeapon[] _nonAutomaticWeapon;
    [SerializeField] private AutomaticWeapon[] _automaticWeapon;
    private bool _dontSee;
    private void Awake()
    {
        _stoppingDistance = _range;
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

            if(_nonAutomaticWeapon.Length != 0)
            {
                for (int i = 0; i < _nonAutomaticWeapon.Length; i++) _nonAutomaticWeapon[i].MakeShoot();
            }
            if(_automaticWeapon.Length != 0)
            {
                for (int i = 0; i < _nonAutomaticWeapon.Length; i++) _automaticWeapon[i].StartShooting(true);
            }
        }
        else
        {
            _dontSee = true;
            StopShooting();
        }

    }
    private void StopShooting()
    {
        if (_automaticWeapon.Length != 0)
        {
            for (int i = 0; i < _nonAutomaticWeapon.Length; i++) _automaticWeapon[i].StartShooting(false);
        }
    }
}

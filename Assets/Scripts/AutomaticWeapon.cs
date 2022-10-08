using System.Collections;
using UnityEngine;

public class AutomaticWeapon : Weapon
{
    private bool _startedShooting;
    private string _target;   
    public override void MakeShoot(bool _startShooting, string _targetTag)
    {
        _target = _targetTag;
        if(_startShooting && !_startedShooting) StartCoroutine("Shooting");
        else { StopCoroutine("Shooting"); _startedShooting = false; }
    }
    private IEnumerator Shooting()
    {
        _startedShooting = true;
        for(; ; )
        {
            Shoot(_target);
            yield return new WaitForSeconds(_firingRate);
        }
    }
}

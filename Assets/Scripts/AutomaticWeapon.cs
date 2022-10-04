using System.Collections;
using UnityEngine;

public class AutomaticWeapon : Weapon
{
    private bool _startedShooting;
    public void StartShooting(bool _start)
    {
        if(_start && !_startedShooting) StartCoroutine("Shooting");
        else { StopCoroutine("Shooting"); _startedShooting = false; }
    }
    private IEnumerator Shooting()
    {
        _startedShooting = true;
        for(; ; )
        {
            Shoot();
            yield return new WaitForSeconds(_firingRate);
        }
    }
}

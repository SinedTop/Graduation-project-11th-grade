using System.Collections;
using UnityEngine;

public class NonAutomaticWeapon : Weapon
{
    private bool _rate;
    public override void MakeShoot(bool _startShooting)
    {
        if (_rate) return;
        Shoot();
        StartCoroutine(Rate());
    }
    private IEnumerator Rate()
    {
        _rate = true;
        yield return new WaitForSeconds(_firingRate);
        _rate = false;
        yield return null;
    }
}

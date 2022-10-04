using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int _money;

    public int _enemyDestroyed;
    public int _moneyCollected;
    public int _numberOfDeaths;

    public int _health = 100;

    public int _maxHealth = 100;
    public float _speed = 1;
    public float _strength = 1;

    public void TakeHit(int _hitHealth)
    {
        _health -= _hitHealth;
        if (_health <= 0) _numberOfDeaths += 1;
    }
}

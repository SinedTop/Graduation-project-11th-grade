using UnityEngine;

public abstract class Stats : MonoBehaviour
{
    [SerializeField] protected int _maxHealth;
    [SerializeField] protected float _strength;
    [SerializeField] protected float _resist;
    protected int _health;
    public float _speed;

    public void TakeHit(float _hitHealth)
    {
        _health -= (int)(_hitHealth - _resist * _hitHealth);
        if(_health <= 0) Die();
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}

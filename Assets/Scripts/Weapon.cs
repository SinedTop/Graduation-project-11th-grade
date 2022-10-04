using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _bulletStartPosition;

    [SerializeField] private float _reloadTime;
    [SerializeField] private float _maxAmmo;
    [SerializeField] protected float _firingRate;
    [Header("Пуля")]
    [SerializeField] private float _maxRange;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private int _power;

    protected float _currentAmmo;

    private bool _reloading;
    private SpriteRenderer _sprite;
    private void Start()
    {
        _currentAmmo = _maxAmmo;
        _sprite = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (transform.rotation.eulerAngles.z <= 270 && transform.rotation.eulerAngles.z >= 90) _sprite.flipY = true;
        else _sprite.flipY = false;
    }
    public virtual void MakeShoot(bool _startShooting)
    {

    }
    protected void Shoot()
    {
        if (_reloading) return;
        if (_currentAmmo <= 0)
        {
            Reload();
            return;
        }
        else
        {
            _currentAmmo--;
            var buffer = Instantiate(_bullet);
            buffer.transform.position = _bulletStartPosition.position;
            buffer.transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - 90));
            var _bull = buffer.GetComponent<Bullet>();
            _bull._maxRange = _maxRange;
            _bull._speed = _bulletSpeed;
            _bull._power = _power;
        }
    }
    public void Reload()
    {
        _reloading = true;
        StartCoroutine(ReloadEnum());
    }
    private IEnumerator ReloadEnum()
    {
        yield return new WaitForSeconds(_reloadTime);
        _currentAmmo = _maxAmmo;
        _reloading = false;
        yield return null;
    }
}

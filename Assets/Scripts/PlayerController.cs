using UnityEngine;

public class PlayerController : Stats
{
    public int _money;

    public int _enemyDestroyed;
    public int _moneyCollected;
    public int _numberOfDeaths;

    public GameObject[] _takedWeapons;
    private int _currentWeapon = 0;
    private Weapon _weapon;
    private GameObject _currentWeaponObj;

    private void Start()
    {
        _health = _maxHealth;
        RefreshWeapon();
    }
    private void FixedUpdate()
    {
        Vector3 moveDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _currentWeaponObj.transform.position;
        float angle = Mathf.Atan2(-moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
        _currentWeaponObj.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (_currentWeapon > 0) _currentWeapon--;
            else _currentWeapon = _takedWeapons.Length - 1;
            RefreshWeapon();
        }
        if (Input.GetKeyDown(KeyCode.E) || Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (_currentWeapon < _takedWeapons.Length - 1) _currentWeapon++;
            else _currentWeapon = 0;
            RefreshWeapon();
        }
        if (_weapon == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            _weapon.MakeShoot(true, "Enemy");
        }
        else if(Input.GetMouseButtonUp(0))
        {
            _weapon.MakeShoot(false, "Enemy");
        }
    }
    private void RefreshWeapon()
    {
        if (_currentWeaponObj != null) Destroy(_currentWeaponObj);
        _currentWeaponObj = Instantiate(_takedWeapons[_currentWeapon], transform);
        _weapon = _currentWeaponObj.GetComponent<Weapon>();
        
    }
    public override void Die()
    {
        _numberOfDeaths++;
        Destroy(gameObject);
    }
}

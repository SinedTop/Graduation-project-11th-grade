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
    public float _resist;

    public GameObject[] _takedWeapons;
    private int _currentWeapon = 0;
    private AutomaticWeapon _currentWeaponAutomatic;
    private NonAutomaticWeapon _currentWeaponNonAutomatic;
    private GameObject _currentWeaponObj;

    public void TakeHit(int _hitHealth)
    {
        _health -= (int)(_hitHealth - _resist * _hitHealth);
        if (_health <= 0) _numberOfDeaths += 1;
    }
    private void Start()
    {
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

        if (Input.GetMouseButtonDown(0))
        {
            if (_currentWeaponAutomatic != null) _currentWeaponAutomatic.StartShooting(true);
            if (_currentWeaponNonAutomatic != null) _currentWeaponNonAutomatic.MakeShoot();
        }
        else if(Input.GetMouseButtonUp(0) && _currentWeaponAutomatic != null)
        {
            _currentWeaponAutomatic.StartShooting(false);
        }
    }
    private void RefreshWeapon()
    {
        if (_currentWeaponObj != null) Destroy(_currentWeaponObj);
        _currentWeaponObj = Instantiate(_takedWeapons[_currentWeapon], transform);
        var _weapon = GetComponent<Weapon>();
        if (_currentWeaponObj.GetComponent<AutomaticWeapon>() != null)
        {
            _currentWeaponAutomatic = _currentWeaponObj.GetComponent<AutomaticWeapon>();
            _currentWeaponNonAutomatic = null;
        }
        if (_currentWeaponObj.GetComponent<NonAutomaticWeapon>() != null)
        {
            _currentWeaponNonAutomatic = _currentWeaponObj.GetComponent<NonAutomaticWeapon>();
            _currentWeaponAutomatic = null;
        }
    }
}

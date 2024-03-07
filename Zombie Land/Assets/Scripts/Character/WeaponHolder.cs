using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public System.Action<WeaponInfo> WeaponChanged;

    [SerializeField] private Transform _SHGrab_target, _SHGrab_hint;
    [SerializeField] private WeaponInfo[] _weaponInstances;

    private int _currentWeapon = 0;

    private void Update()
    {
        if(Input.GetButtonDown("WeaponSwitchNext"))
            NextWeapon();
        if (Input.GetButtonDown("WeaponSwitchPrevious"))
            PreviousWeapon();
    }

    private void Start()
    {
        SwapWeapon(0);
    }

    [ContextMenu("Next Weapon")]
    private void NextWeapon()
    {
        do {
            _currentWeapon++;
        }
        while (PlayerPrefs.GetInt("Weapon" + _currentWeapon % _weaponInstances.Length) != 1);
        SwapWeapon(_currentWeapon);
    }
    [ContextMenu("Previous Weapon")]
    private void PreviousWeapon()
    {
        do
        {
            _currentWeapon += _weaponInstances.Length - 1;
        }
        while (PlayerPrefs.GetInt("Weapon" + _currentWeapon % _weaponInstances.Length) != 1);
        SwapWeapon(_currentWeapon);
    }
    public void SwapWeapon(int _weaponIndex)
    {
        
        UnequipAll();
        _weaponInstances[_weaponIndex % _weaponInstances.Length].gameObject.SetActive(true);
        WeaponChanged?.Invoke(_weaponInstances[_weaponIndex % _weaponInstances.Length]);
    }

    private void UnequipAll()
    {
        foreach(WeaponInfo weaponInfo in _weaponInstances)
        {
            weaponInfo.gameObject.SetActive(false);
        }
    }
}

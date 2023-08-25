using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public System.Action<WeaponStruct.WeaponInfoStruct> WeaponChanged;

    [SerializeField] private Transform _SHGrab_target, _SHGrab_hint;
    [SerializeField] private WeaponInfo[] _weaponInstances;

    private int _currentWeapon = 0;

    private void Start()
    {
        SwapWeapon(0);
    }

    [ContextMenu("Next Weapon")]
    private void NextWeapon()
    {
        SwapWeapon(++_currentWeapon);
    }
    public void SwapWeapon(int _weaponIndex)
    {
        if(_weaponIndex >= _weaponInstances.Length)
        {
            Debug.LogError("Choosen weapon index is out of bounds");
            return;
        }
        UnequipAll();
        _weaponInstances[_weaponIndex].gameObject.SetActive(true);
        WeaponChanged?.Invoke(_weaponInstances[_weaponIndex]._weaponInfo);
    }

    private void UnequipAll()
    {
        foreach(WeaponInfo weaponInfo in _weaponInstances)
        {
            weaponInfo.gameObject.SetActive(false);
        }
    }
}

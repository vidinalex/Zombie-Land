using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    [SerializeField]
    public WeaponStruct.WeaponInfoStruct _weaponInfo;

    private int _currentAmmo;

    private void Awake()
    {
        _currentAmmo = _weaponInfo._weaponParams.InitialAmmoAmount;
    }

    public void ReduceAmmo(int amount)
    {
        _currentAmmo -= amount;

        UIWeaponManager.Default.UpdateFillAmount(_weaponInfo._weaponParams.Index, _weaponInfo._weaponParams.InitialAmmoAmount, _currentAmmo);
    }

    public bool IsAbleToShoot()
    {
        if(_currentAmmo > 0)
        {
            return true;
        }

        return false;
    }
}

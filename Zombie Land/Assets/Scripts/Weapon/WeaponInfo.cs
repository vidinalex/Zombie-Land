using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    [SerializeField]
    public WeaponStruct.WeaponInfoStruct _weaponInfo;

    private int _currentAmmo;
    private string PREFS_WEAPON_NAME = "Weapon", PREFS_UPGRADE_NAME = "Upgrade";

    private void Awake()
    {
        _currentAmmo = _weaponInfo._weaponParams.InitialAmmoAmount + (_weaponInfo._weaponParams.AmmoAmountMod * PlayerPrefs.GetInt(PREFS_WEAPON_NAME + _weaponInfo._weaponParams.Index + PREFS_UPGRADE_NAME + 1));
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

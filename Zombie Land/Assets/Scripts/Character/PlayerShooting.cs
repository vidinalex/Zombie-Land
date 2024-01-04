using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private RecoilCompressor _recoilCompressor;
    [SerializeField] private WeaponHolder _weaponHolder;

    private WeaponInfo _currentWeaponInfo;

    private float _elapsedTime;

    private void OnEnable()
    {
        _weaponHolder.WeaponChanged += SetUpWeapon;
    }

    private void OnDisable()
    {
        _weaponHolder.WeaponChanged -= SetUpWeapon;
    }

    private void SetUpWeapon(WeaponInfo _weaponInfo)
    {
        _currentWeaponInfo = _weaponInfo;

        UIWeaponManager.Default.SetActiveWeapon(_currentWeaponInfo._weaponInfo._weaponParams.Index);
    }

    private void Update()
    {
        _elapsedTime -= Time.deltaTime;

        if (Input.GetMouseButton(0) && _currentWeaponInfo.IsAbleToShoot())
        {
            HandleShooting();
            HandleFX();
        }
        else
        {
            HandleEndShooting();
        }
    }

    private void HandleEndShooting()
    {
        if(_currentWeaponInfo._weaponInfo._muzzleFlash)
            _currentWeaponInfo._weaponInfo._muzzleFlash.Stop();
    }

    private void HandleFX()
    {
        if (_currentWeaponInfo._weaponInfo._muzzleFlash)
            _currentWeaponInfo._weaponInfo._muzzleFlash.Play();
    }

    private void HandleShooting()
    {
        if (_elapsedTime <= 0)
        {
            _elapsedTime = _currentWeaponInfo._weaponInfo._attackSpeed;
            Instantiate(_currentWeaponInfo._weaponInfo._bulletInstance, _currentWeaponInfo._weaponInfo._bulletSpawnPoint.position, transform.rotation);

            _recoilCompressor.AddRecoil(_currentWeaponInfo._weaponInfo._recoilStrength);
            CameraShaker.Default.Shake(_currentWeaponInfo._weaponInfo._reciolFrequency, _currentWeaponInfo._weaponInfo._recoilDuration);

            _currentWeaponInfo.ReduceAmmo(1);
        }
    }
}

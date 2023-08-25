using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private RecoilCompressor _recoilCompressor;
    [SerializeField] private WeaponHolder _weaponHolder;

    private WeaponStruct.WeaponInfoStruct _currentWeaponInfo;

    private float _elapsedTime;

    private void OnEnable()
    {
        _weaponHolder.WeaponChanged += SetUpWeapon;
    }

    private void OnDisable()
    {
        _weaponHolder.WeaponChanged -= SetUpWeapon;
    }

    private void SetUpWeapon(WeaponStruct.WeaponInfoStruct _weaponInfo)
    {
        _currentWeaponInfo = _weaponInfo;
    }

    private void Update()
    {
        _elapsedTime -= Time.deltaTime;

        if (Input.GetMouseButton(0))
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
        if(_currentWeaponInfo._muzzleFlash)
            _currentWeaponInfo._muzzleFlash.Stop();
    }

    private void HandleFX()
    {
        if (_currentWeaponInfo._muzzleFlash)
            _currentWeaponInfo._muzzleFlash.Play();
    }

    private void HandleShooting()
    {
        if (_elapsedTime <= 0)
        {
            _elapsedTime = _currentWeaponInfo._attackSpeed;
            Instantiate(_currentWeaponInfo._bulletInstance, _currentWeaponInfo._bulletSpawnPoint.position, transform.rotation);

            _recoilCompressor.AddRecoil(_currentWeaponInfo._recoilStrength);
            CameraShaker.Default.Shake(_currentWeaponInfo._reciolFrequency, _currentWeaponInfo._recoilDuration);
        }
    }
}

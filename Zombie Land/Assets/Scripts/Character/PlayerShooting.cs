using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] 
    private RecoilCompressor _recoilCompressor;
    [SerializeField] 
    private WeaponHolder _weaponHolder;
    [SerializeField]
    private AudioClip _clipReload;

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
        _elapsedTime = 0;

        AudioManager.Default.PlaySoundFXAtPoint(_clipReload, transform);
        AudioManager.Default.DestroySingleSources();
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

        AudioManager.Default.DestroySingleSources();
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
            _elapsedTime = _currentWeaponInfo._weaponInfo._weaponParams._attackSpeed;
            Instantiate(_currentWeaponInfo._weaponInfo._bulletInstance, _currentWeaponInfo._weaponInfo._bulletSpawnPoint.position, transform.rotation);

            _recoilCompressor.AddRecoil(_currentWeaponInfo._weaponInfo._weaponParams._recoilStrength);
            CameraShaker.Default.Shake(_currentWeaponInfo._weaponInfo._weaponParams._reciolFrequency, _currentWeaponInfo._weaponInfo._weaponParams._recoilDuration);

            _currentWeaponInfo.ReduceAmmo(1);

            if(_currentWeaponInfo._weaponInfo._weaponParams.ShotSound)
                if (_currentWeaponInfo._weaponInfo._weaponParams.isAudioSingle)
                {
                    AudioManager.Default.PlaySoundFXAtPointSingle(_currentWeaponInfo._weaponInfo._weaponParams.ShotSound, transform);
                }
                else
                {
                    AudioManager.Default.PlaySoundFXAtPoint(_currentWeaponInfo._weaponInfo._weaponParams.ShotSound, transform);
                }  
        }
    }
}

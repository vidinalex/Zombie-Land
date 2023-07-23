using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private GameObject _bulletInstance;
    [SerializeField] private float _attackSpeed, _recoilStrength;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private RecoilCompressor _recoilCompressor;

    private float _elapsedTime;
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
        _muzzleFlash.Stop();
    }

    private void HandleFX()
    {
        _muzzleFlash.Play();
    }

    private void HandleShooting()
    {
        if (_elapsedTime <= 0)
        {
            _elapsedTime = _attackSpeed;
            Instantiate(_bulletInstance, _bulletSpawnPoint.position, transform.rotation);

            _recoilCompressor.AddRecoil(_recoilStrength);
        }
    }
}

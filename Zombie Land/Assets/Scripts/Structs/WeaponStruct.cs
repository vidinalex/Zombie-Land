using System;
using UnityEngine;

public static class WeaponStruct
{
    [Serializable]
    public struct WeaponInfoStruct
    {
        [SerializeField] public Transform _bulletSpawnPoint;
        [SerializeField] public GameObject _bulletInstance;
        [SerializeField] public float _attackSpeed, _recoilStrength, _recoilDuration, _reciolFrequency;
        [SerializeField] public ParticleSystem _muzzleFlash;
    }
}

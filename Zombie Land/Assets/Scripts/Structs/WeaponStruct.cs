using System;
using UnityEngine;

public static class WeaponStruct
{
    [Serializable]
    public struct WeaponInfoStruct
    {
        [SerializeField] public Transform _bulletSpawnPoint;
        [SerializeField] public GameObject _bulletInstance;
        [SerializeField] public ParticleSystem _muzzleFlash;
        [SerializeField] public WeaponParams _weaponParams;
    }
}

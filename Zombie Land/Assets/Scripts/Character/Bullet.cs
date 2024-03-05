using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _initialSpeed, _dmg;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private string _enemyTag;
    [SerializeField] private GameObject _bloodFX, _impactFX;
    [SerializeField] private WeaponParams _weaponInfo;

    private string PREFS_WEAPON_NAME = "Weapon", PREFS_UPGRADE_NAME = "Upgrade";

    private void Start()
    {
        _rb.AddForce(transform.forward * _initialSpeed);

        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == _enemyTag)
        {
            Instantiate(_bloodFX, transform.position, Random.rotation);

            if(collision.gameObject.TryGetComponent<IDamagable>(out IDamagable _IDamagable))
            {
                _IDamagable.RecieveDMG(_weaponInfo.InitialDMG + (_weaponInfo.DamageMod * PlayerPrefs.GetInt(PREFS_WEAPON_NAME + _weaponInfo.Index + PREFS_UPGRADE_NAME + 0)));
            }
        }
        else
        {
            Instantiate(_impactFX, transform.position, Quaternion.Inverse(transform.rotation));
        }

        Destroy(gameObject);
    }
}

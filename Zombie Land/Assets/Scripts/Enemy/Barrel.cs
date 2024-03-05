using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour, IDamagable
{
    [SerializeField]
    private GameObject _explosionInstance, _explosionVFX;
    [SerializeField]
    private AudioClip _explosionClip;

    public void Die()
    {
        Instantiate(_explosionInstance, transform.position, Quaternion.identity);
        Instantiate(_explosionVFX, transform.position, Quaternion.identity);
        AudioManager.Default.PlaySoundFXAtPoint(_explosionClip, transform);

        Destroy(gameObject);
    }

    public void RecieveDMG(float _dmg)
    {
        Die();
    }
}

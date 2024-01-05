using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : MonoBehaviour
{
    [SerializeField]
    private float _dmg;
    [Space(5)]
    [SerializeField]
    private float _frequency, _duration;

    private void Start()
    {
        Destroy(gameObject, 0.1f);
        CameraShaker.Default.Shake(_frequency, _duration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable _IDamagable))
        {
            if(collision.gameObject.tag == "Player")
            {
                _IDamagable.RecieveDMG(_dmg/4);
            }
            else
            {
                _IDamagable.RecieveDMG(_dmg);
            }
            
        }
    }
}

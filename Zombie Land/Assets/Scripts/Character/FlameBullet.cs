using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBullet : MonoBehaviour
{
    [SerializeField] private float _dmg, _lifeTime;
    [SerializeField] private string _enemyTag;

    private void Start()
    {
        Destroy(gameObject.transform.parent.gameObject, _lifeTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _enemyTag)
        {
            if (other.gameObject.TryGetComponent<IDamagable>(out IDamagable _IDamagable))
            {
                _IDamagable.RecieveDMG(_dmg);
            }
        }
    }
}

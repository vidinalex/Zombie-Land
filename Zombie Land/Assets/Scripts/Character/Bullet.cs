using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _initialSpeed;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private string _enemyTag;
    [SerializeField] private GameObject _bloodFX, _impactFX;

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
        }
        else
        {
            Instantiate(_impactFX, transform.position, Quaternion.Inverse(transform.rotation));
        }

        Destroy(gameObject);
    }
}

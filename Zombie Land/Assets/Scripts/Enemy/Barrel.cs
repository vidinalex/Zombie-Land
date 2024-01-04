using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour, IDamagable
{
    [SerializeField]
    private GameObject _explosionInstance;

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void RecieveDMG(float _dmg)
    {
        Die();
    }
}

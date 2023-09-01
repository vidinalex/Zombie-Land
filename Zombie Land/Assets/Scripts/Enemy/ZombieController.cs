using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour, IDamagable
{
    [SerializeField] private float _maxHP;
    [SerializeField] private HealthBarController _healthBarController;
    [SerializeField] private ZombieRagdollController _ragdollController;

    private float _currentHP;

    private void Start()
    {
        _currentHP = _maxHP;
    }

    public void RecieveDMG(float _dmg)
    {
        _currentHP -= _dmg;
        _healthBarController.ReciveDMG(_dmg, _maxHP);

        if (_currentHP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (_ragdollController)
        {
            _ragdollController.SetRagdoll(true);
        }
    }
}

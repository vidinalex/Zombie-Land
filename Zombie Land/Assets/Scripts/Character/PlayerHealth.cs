using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField]
    private float _maxHP;
    [SerializeField]
    private HealthBarController _healthBarController;
    [SerializeField]
    private PlayerMovement _pm;
    [SerializeField]
    private PlayerShooting _ps;

    private bool _isDead = false;
    private float _currentHP;

    private void Start()
    {
        _currentHP = _maxHP;
    }

    public void Die()
    {
        _isDead = true;

        _pm.enabled = false;
        _ps.enabled = false;

        Manager.Default.DefeatMenu();
    }

    public void RecieveDMG(float _dmg)
    {
        _currentHP -= _dmg;

        BloodOverlayManager.Default.AddEffectMod(0.2f);

        if (_healthBarController)
            _healthBarController.ReciveDMG(_dmg, _maxHP);

        if (_currentHP <= 0 && !_isDead)
        {
            Die();
        }
    }
}

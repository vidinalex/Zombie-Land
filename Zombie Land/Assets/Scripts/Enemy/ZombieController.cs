using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class ZombieController : MonoBehaviour, IDamagable
{
    [SerializeField] private float _maxHP, _attackSpeedTime, _damageAmount;
    [SerializeField] private Animator _animator;
    [SerializeField] private HealthBarController _healthBarController;
    [SerializeField] private ZombieRagdollController _ragdollController;

    private float _currentHP, currentAttackTime;
    private Transform destinationTarget;

    private const float MIN_ATTACK_DIST = 2f, ATTACK_DELAY = 0.3f;

    private void Start()
    {
        _currentHP = _maxHP;

        SetDestinationTarget();
    }

    private void Update()
    {
        currentAttackTime -= Time.deltaTime;

        if (!destinationTarget)
            return;

        float dist = Vector3.Distance(transform.position, destinationTarget.position);
        if (dist <= MIN_ATTACK_DIST && currentAttackTime <= 0)
        {
            Attack();
        }
    }

    private void Attack()
    {
        currentAttackTime = _attackSpeedTime;

        if(destinationTarget.TryGetComponent<IDamagable>(out IDamagable damageTarget))
        {
            StartCoroutine(CDelayDamage(damageTarget, ATTACK_DELAY));

            if (!_animator)
                return;

            _animator.SetTrigger("Attack");
        }        
    }

    private IEnumerator CDelayDamage(IDamagable target, float delay)
    {
        yield return new WaitForSeconds(delay);
        target.RecieveDMG(_damageAmount);
    }

    private void SetDestinationTarget()
    {
        destinationTarget = Manager.Default.GetPlayerCharacterTransform();
        if (TryGetComponent<AIDestinationSetter>(out AIDestinationSetter aiDestinationSetter))
        {
            aiDestinationSetter.target = destinationTarget;
        }
    }

    public void RecieveDMG(float _dmg)
    {
        _currentHP -= _dmg;

        if(_healthBarController)
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

        LevelManager.Default.ZombieKilled();

        Destroy(gameObject, 4f);
        this.enabled = false;
    }
}

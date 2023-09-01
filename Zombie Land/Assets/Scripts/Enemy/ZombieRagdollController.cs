using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRagdollController : MonoBehaviour
{
    [SerializeField] private List<Collider> _ragdollRegions;
    [SerializeField] private Animator _characterAnimator;
    [SerializeField] private AIPath _characterAIPath;
    [SerializeField] private Collider _characterMainCollider;
    [SerializeField] private GameObject _characterHealth;
    [SerializeField] private Rigidbody _characterRB;

    public void SetRagdoll(bool state)
    {
        _characterAnimator.enabled = !state;
        _characterRB.isKinematic = !state;
        foreach (Collider c in _ragdollRegions)
        {
            c.enabled = state;
        }
        _characterAIPath.enabled = !state;
        _characterHealth.SetActive(!state);
        StartCoroutine(WaitAndDiasbleMainCollider(state));
    }

    private IEnumerator WaitAndDiasbleMainCollider(bool state)
    {
        yield return new WaitForSeconds(0.1f);
        _characterMainCollider.enabled = !state;
    }

    [ContextMenu("SetRagdollTrue")]
    private void SetRagdollTrue()
    {
        SetRagdoll (true);
    }

    [ContextMenu("SetRagdollFalse")]
    private void SetRagdollFalse()
    {
        SetRagdoll (false);
    }
}

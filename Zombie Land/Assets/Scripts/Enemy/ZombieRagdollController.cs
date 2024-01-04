using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRagdollController : MonoBehaviour
{
    [SerializeField] private List<Collider> _ragdollRegions;
    [SerializeField] private List<Rigidbody> _ragdollRbs;
    [SerializeField] private Animator _characterAnimator;
    [SerializeField] private AIPath _characterAIPath;
    [SerializeField] private Collider _characterMainCollider;
    [SerializeField] private GameObject _characterHealth;
    [SerializeField] private Rigidbody _characterRB;

    public void SetRagdoll(bool state)
    {
        _characterRB.isKinematic = state;
        _characterMainCollider.enabled = !state;
        _characterAnimator.enabled = !state;

        foreach (Collider c in _ragdollRegions)
        {
            c.enabled = state;
        }
        foreach (Rigidbody rb in _ragdollRbs)
        {
            rb.isKinematic = !state;
        }

        _characterAIPath.enabled = !state;
        _characterHealth.SetActive(!state);
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

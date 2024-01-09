using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponentsController : MonoBehaviour
{
    public Action StateUpdated;

    [SerializeField]
    private BuyingElement[] _buyingElements;

    private void OnEnable()
    {
        foreach (var buyingElement in _buyingElements)
        {
            buyingElement.StateUpdated += UpdateAllState;
        }
    }

    private void OnDisable()
    {
        foreach (var buyingElement in _buyingElements)
        {
            buyingElement.StateUpdated -= UpdateAllState;
        }
    }

    private void UpdateAllState()
    {
        StateUpdated?.Invoke();
    }

    [ContextMenu("Set Up")]
    private void SetUp()
    {
        _buyingElements = FindObjectsByType<BuyingElement>(FindObjectsInactive.Include, FindObjectsSortMode.None);
    }
}

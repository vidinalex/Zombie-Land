using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageWeaponController : MonoBehaviour, IObserveSetter
{
    [SerializeField]
    private GameObject[] _rootWeaponPool, _buyingElementsPool;

    private const string PREFS_WEAPON_NAME = "Weapon";

    private void Start()
    {
        SetObservable(1);
    }

    public void SetObservable(int index)
    {
        index--;
        foreach (GameObject rootWeapon in _rootWeaponPool)
        {
            rootWeapon.SetActive(false);
        }
        foreach (GameObject buyingElement in _buyingElementsPool)
        {
            buyingElement.SetActive(false);
        }

        _rootWeaponPool[index].SetActive(true);
        if (PlayerPrefs.GetInt(PREFS_WEAPON_NAME + index, 0) == 1)
        {
            _buyingElementsPool[index].SetActive(true);
        }
    }
}

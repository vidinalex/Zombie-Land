using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageWeaponController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _rootWeaponPool, _buyingElementsPool;

    private const string PREFS_WEAPON_NAME = "Weapon";

    private void Start()
    {
        SetObservableWeapon(1);
    }

    public void SetObservableWeapon(int index)
    {
        index--;
        foreach(GameObject rootWeapon in _rootWeaponPool)
        {
            rootWeapon.SetActive(false);
        }
        foreach(GameObject buyingElement in _buyingElementsPool)
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

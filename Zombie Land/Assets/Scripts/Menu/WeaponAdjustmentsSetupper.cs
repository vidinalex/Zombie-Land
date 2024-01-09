using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAdjustmentsSetupper : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _adjustmentsPool; // 1. Damage 2. Ammo 3. Flashlight 4. ACOG 5. Silencer
    [SerializeField]
    private int _weaponIndex;

    private const string PREFS_WEAPON_NAME = "Weapon", PREFS_UPGRADE_NAME = "Upgrade";
    private string _prefsFinalName;
    private WeaponComponentsController _weaponComponentsController;

    private void Awake()
    {
        _weaponComponentsController = FindAnyObjectByType<WeaponComponentsController>(FindObjectsInactive.Include);
        _prefsFinalName = PREFS_WEAPON_NAME + _weaponIndex + PREFS_UPGRADE_NAME;
    }

    private void OnEnable()
    {
        SetUpAdjustments();

        _weaponComponentsController.StateUpdated += SetUpAdjustments;
    }

    private void OnDisable()
    {
        foreach(GameObject adjustment in _adjustmentsPool)
        {
            adjustment.SetActive(false);
        }

        _weaponComponentsController.StateUpdated -= SetUpAdjustments;
    }

    private void SetUpAdjustments()
    {
        for (int i = 2; i < 5; i++)
        {
            if (PlayerPrefs.GetInt(_prefsFinalName + i, 0) == 1)
            {
                _adjustmentsPool[i - 2].SetActive(true);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSkinController : MonoBehaviour, IObserveSetter
{
    [SerializeField]
    private GameObject[] _rootSkinPool;

    private const string PREFS_WEAPON_NAME = "Weapon";

    private void Start()
    {
        SetObservable(1);
    }

    public void SetObservable(int index)
    {
        index--;
        foreach (GameObject rootWeapon in _rootSkinPool)
        {
            rootWeapon.SetActive(false);
        }

        _rootSkinPool[index].SetActive(true);
    }
}

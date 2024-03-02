using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChangerPlaymode : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _skinPool;

    private void Start()
    {
        foreach (var skin in _skinPool)
        {
            skin.SetActive(false);
        }

        _skinPool[PlayerPrefs.GetInt("Skin", 0)].SetActive(true);
    }
}

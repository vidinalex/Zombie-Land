using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChangerPlaymode : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _skinPool;

    private const string PREFS_NAME = "Skin";

    private void Start()
    {
        foreach (var skin in _skinPool)
        {
            skin.SetActive(false);
        }        

        for (int i = 0; i < _skinPool.Capacity; i++)
        {
            if(PlayerPrefs.GetInt(PREFS_NAME + i, 0) == 2)
            {
                _skinPool[i].SetActive(true);
            }
        }
    }

    public void UpdateSkin()
    {
        foreach (var skin in _skinPool)
        {
            skin.SetActive(false);
        }

        for (int i = 0; i < _skinPool.Capacity; i++)
        {
            if (PlayerPrefs.GetInt(PREFS_NAME + i, 0) == 2)
            {
                _skinPool[i].SetActive(true);
            }
        }
    }
}

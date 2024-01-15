using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaymodeWeaponSetup : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _attachments;
    [SerializeField]
    private string PREFS_NAME;

    private void Start()
    {
        for (int i = 2; i < 5; i++)
        {
            if(PlayerPrefs.GetInt(PREFS_NAME + i, 0) != 0)
            {
                _attachments[i - 2].SetActive(true);
            }
            else
            {
                _attachments[i - 2].SetActive(false);
            }
        }
    }
}
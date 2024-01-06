using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyingElement : MonoBehaviour
{
    [SerializeField]
    private Button[] _upgradeBtnPool;
    [SerializeField]
    private Image[] _filler;
    [SerializeField]
    private GameObject[] _unBought, _bought;
    [SerializeField]
    private TMP_Text[] _costsName;
    [SerializeField]
    private int[] _maxUpgradeLevel = { 3, 3, 1, 1, 1 };
    [SerializeField]
    private int _weaponIndex;
    [SerializeField]
    private CostsMatrix[] _costsMatrix;
    [Serializable]
    private struct CostsMatrix
    {
        public int[] _costsAmount;
    }

    private const string PREFS_WEAPON_NAME = "Weapon", PREFS_UPGRADE_NAME = "Upgrade";

    private int _currentMoney;

    private void Start()
    {
        UpgradeState();
    }

    private void UpgradeState()
    {
        _currentMoney = MoneyMenuController.Default.GetCurrentMoney();
        for (int i = 0; i < _upgradeBtnPool.Length; i++)
        {
            int state = PlayerPrefs.GetInt(PREFS_WEAPON_NAME + _weaponIndex + PREFS_UPGRADE_NAME + i);
            if(state == 0)
            {
                _filler[i].fillAmount = 0;
                _unBought[i].gameObject.SetActive(true);
                _bought[i].gameObject.SetActive(false);

                _costsName[i].text = _costsMatrix[i]._costsAmount[state].ToString();

                if(_currentMoney >= _costsMatrix[i]._costsAmount[state])
                {
                    _upgradeBtnPool[i].interactable = true;
                }
                else
                {
                    _upgradeBtnPool[i].interactable = true;
                }
            }
            else if (state == _maxUpgradeLevel[i])
            {
                _filler[i].fillAmount = 1;
                _unBought[i].gameObject.SetActive(false);
                _bought[i].gameObject.SetActive(true);

                _upgradeBtnPool[i].interactable = false;
            }
            else
            {
                _filler[i].fillAmount = (float) state / _maxUpgradeLevel[i];
                _unBought[i].gameObject.SetActive(true);
                _bought[i].gameObject.SetActive(false);

                _costsName[i].text = _costsMatrix[i]._costsAmount[state].ToString();

                if (_currentMoney >= _costsMatrix[i]._costsAmount[state])
                {
                    _upgradeBtnPool[i].interactable = true;
                }
                else
                {
                    _upgradeBtnPool[i].interactable = true;
                }
            }
        }
    }

    public void ProceedBuy(int index)
    {
        int state = PlayerPrefs.GetInt(PREFS_WEAPON_NAME + _weaponIndex + PREFS_UPGRADE_NAME + index);
        MoneyMenuController.Default.UpdateMoney(-_costsMatrix[index]._costsAmount[state]);

        PlayerPrefs.SetInt(PREFS_WEAPON_NAME + _weaponIndex + PREFS_UPGRADE_NAME + index, ++state);

        UpgradeState();
    }
}

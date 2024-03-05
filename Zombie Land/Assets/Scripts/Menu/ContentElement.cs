using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentElement : MonoBehaviour
{
    public int _cost;

    [SerializeField]
    private string PREFS_NAME = "Weapon";
    [SerializeField]
    private int PREFS_INDEX = 0;

    [SerializeField]
    private GameObject[] _statePool;
    [SerializeField]
    private Button _BTN_Buy;
    [SerializeField]
    private SkinChangerPlaymode _skinChanger;

    private void OnEnable()
    {
        UpdateCurrentState();
    }

    public void UpdateCurrentState()
    {
        foreach (var stage in _statePool)
        {
            stage.SetActive(false);
        }

        _statePool[PlayerPrefs.GetInt(PREFS_NAME + PREFS_INDEX, 0)].SetActive(true);

        if(MoneyMenuController.Default.GetCurrentMoney() >= _cost)
        {
            _BTN_Buy.interactable = true;
        }
        else
        {
            _BTN_Buy.interactable = false;
        }
    }

    public void ApplySkin(bool isActive)
    {
        if(PlayerPrefs.GetInt(PREFS_NAME + PREFS_INDEX, 0) <= 0)
        {
            return;
        }

        if (isActive)
        {
            PlayerPrefs.SetInt(PREFS_NAME + PREFS_INDEX, 2);
            AudioManager.Default.PlaySoundFXPreset(AudioManager.Presets.Click);            
        }
        else
        {
            PlayerPrefs.SetInt(PREFS_NAME + PREFS_INDEX, 1);
        }

        UpdateCurrentState();
        _skinChanger.UpdateSkin();
    }

    public void BuyElement()
    {
        PlayerPrefs.SetInt(PREFS_NAME + PREFS_INDEX, 1);
    }
}

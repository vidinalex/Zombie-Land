using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyMenuController : MonoBehaviour
{
    #region Singleton
    private static MoneyMenuController _default;
    public static MoneyMenuController Default => _default;

    private void Awake()
    {
        _default = this;
    }
    #endregion

    [SerializeField]
    private TMP_Text _moneyTextField;
    [SerializeField]
    private float _changeSpeed = 1f;

    private int _currentMoney, _tempMoney;
    private Coroutine _moneyUpdater;

    private void Start()
    {
        _currentMoney = PlayerPrefs.GetInt("Money", 0);
        _tempMoney = _currentMoney;
        _moneyTextField.text = _tempMoney.ToString();
    }

    private IEnumerator CUpdateMoneyAmount()
    {
        float lerp = 0f;

        while (_tempMoney != _currentMoney)
        {
            lerp += Time.deltaTime / _changeSpeed;
            _tempMoney = (int)Mathf.Lerp(_tempMoney, _currentMoney, lerp);
            _moneyTextField.text = _tempMoney.ToString();

            yield return null;
        }

        _moneyTextField.text = _tempMoney.ToString();
    }

    public void UpdateMoney(int difference)
    {
        _currentMoney += difference;
        PlayerPrefs.SetInt("Money", _currentMoney);

        if(_moneyUpdater != null)
        {
            StopCoroutine(_moneyUpdater);
        }

        StartCoroutine(CUpdateMoneyAmount());
    }

    public int GetCurrentMoney()
    {
        return _currentMoney;
    }
}

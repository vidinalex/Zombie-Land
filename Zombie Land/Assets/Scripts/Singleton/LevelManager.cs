using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    private static LevelManager _default;
    public static LevelManager Default => _default;

    private void Awake()
    {
        _default = this;
    }
    #endregion

    [SerializeField]
    private List<LevelSettings> _settings;
    [SerializeField]
    private TMP_Text _progressBarTextfield, _rewardTextfield;
    [SerializeField]
    private Image _progressBarFill;
    [SerializeField]
    private int _maxZombieInstances;
    [SerializeField]
    private Transform[] _spawnPoints;

    private int
        _targetFrags,
        _currentFrags,
        _currentLevel,
        _currentZombieInstances;

    private LevelSettings _currentLevelSettings;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _currentLevel = PlayerPrefs.GetInt("Level", 0);
        _currentLevelSettings = _settings[Mathf.Min(_settings.Count - 1, _currentLevel)];
        _targetFrags = _currentLevelSettings.TargetFrags;

        for (int i = 0; i < _maxZombieInstances; i++)
        {
            SpawnZombie();
        }

        UpdateProgressBar();
    }

    private void SpawnZombie()
    {
        Instantiate(_currentLevelSettings.ZombiePool[Random.Range(0, _currentLevelSettings.ZombiePool.Count)], _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity);
        _currentZombieInstances++;
    }

    private bool isAlreadyWin = false;

    public void ZombieKilled()
    {
        _currentFrags++;
        _currentZombieInstances--;

        UpdateProgressBar();
        SpawnZombie();

        if (_currentFrags >= _targetFrags && !isAlreadyWin)
        {
            isAlreadyWin = true;
            Win();
        }
    }

    private void Win()
    {
        int currReward = _currentLevelSettings.Reward;
        MoneyMenuController.Default.UpdateMoney(currReward);
        _rewardTextfield.text = "+" + currReward;
        Manager.Default.WinMenu();
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 0) + 1);
    }

    private void UpdateProgressBar()
    {
        _progressBarFill.fillAmount = (float)_currentFrags / _targetFrags;
        _progressBarTextfield.text = _currentFrags + " / " + _targetFrags;
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    #region Singleton
    private static MenuManager _default;
    public static MenuManager Default => _default;

    private void Awake()
    {
        _default = this;

        Application.targetFrameRate = 60;

        if (PlayerPrefs.GetInt(PREFS_FIRST_LAUNCH, 0) == 0)
        {
            PlayerPrefs.SetInt(PREFS_FIRST_LAUNCH, 1);
            PlayerPrefs.SetInt(PREFS_WEAPON_NAME + 0, 1);
            PlayerPrefs.SetInt(PREFS_WEAPON_NAME + 0 + PREFS_UPGRADE_NAME + 2, 1);
            PlayerPrefs.SetInt(PREFS_WEAPON_NAME + 0 + PREFS_UPGRADE_NAME + 1, 3);
            PlayerPrefs.SetInt(PREFS_WEAPON_NAME + 1, 1);
            PlayerPrefs.SetInt(PREFS_SKIN_NAME + 0, 2);
            PlayerPrefs.SetInt("Money", 40000);
            //PlayerPrefs.SetInt("Level", 5);

            PlayerPrefs.SetInt(PREFS_WEAPON_NAME + 2, 1);
            PlayerPrefs.SetInt(PREFS_WEAPON_NAME + 3, 1);
            PlayerPrefs.SetInt(PREFS_WEAPON_NAME + 4, 1);
            PlayerPrefs.SetInt(PREFS_WEAPON_NAME + 5, 1);
            PlayerPrefs.SetInt(PREFS_WEAPON_NAME + 6, 1);
        }

        PlayerPrefs.SetInt("Weapon5", 0);
    }
    #endregion

    [SerializeField]
    private GameObject[] _stagesPool;
    [SerializeField]
    private LevelElement[] _levelElementPool;
    [SerializeField]
    private Curtain _curtain;

    private Stack<GameObject> _stagesStack = new Stack<GameObject>();
    private const string
        PREFS_FIRST_LAUNCH = "FirstLaunch",
        PREFS_WEAPON_NAME = "Weapon",
        PREFS_UPGRADE_NAME = "Upgrade",
        PREFS_SKIN_NAME = "Skin",
        PREFS_LEVEL = "Level";

    private void Start()
    {
        _stagesStack.Push(_stagesPool[0]);

        ApplyLevelState();
        AudioManager.Default.PlayBGPreset(AudioManager.Presets.MMenu);
    }

    private void ApplyLevelState()
    {
        int targetLevel = PlayerPrefs.GetInt(PREFS_LEVEL, 0);

        for (int i = 0; i < _levelElementPool.Length; i++)
        {
            if (i == targetLevel)
            {
                _levelElementPool[i].SetNext();
            }
            else
            {
                if (i < targetLevel)
                {
                    _levelElementPool[i].SetUnlocked();
                }
                else
                {
                    _levelElementPool[i].SetLocked();
                }
            }
        }
    }

    public void GoToStage(int index)
    {
        _stagesStack.Peek().SetActive(false);
        _stagesStack.Push(_stagesPool[index]);
        _stagesStack.Peek().SetActive(true);

        AudioManager.Default.PlaySoundFXPreset(AudioManager.Presets.Click);
    }

    public void GoToBack()
    {
        _stagesStack.Pop().SetActive(false);
        _stagesStack.Peek().SetActive(true);

        AudioManager.Default.PlaySoundFXPreset(AudioManager.Presets.Click);
    }

    public void StartGame()
    {
        _curtain.OnOpen += LoadGameScene;
        _curtain.OpenCurtain();
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
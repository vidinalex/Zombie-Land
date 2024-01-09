using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    #region Singleton
    private static MenuManager _default;
    public static MenuManager Default => _default;

    private void Awake()
    {
        _default = this;

        Application.targetFrameRate = 300;

        if(PlayerPrefs.GetInt(PREFS_FIRST_LAUNCH, 0) == 0)
        {
            PlayerPrefs.SetInt(PREFS_FIRST_LAUNCH, 1);
            PlayerPrefs.SetInt(PREFS_WEAPON_NAME + 0, 1);
            PlayerPrefs.SetInt(PREFS_WEAPON_NAME + 0 + PREFS_UPGRADE_NAME + 2, 1);
            PlayerPrefs.SetInt(PREFS_WEAPON_NAME + 0 + PREFS_UPGRADE_NAME + 1, 3);
            PlayerPrefs.SetInt(PREFS_WEAPON_NAME + 1, 1);
            PlayerPrefs.SetInt("Money", 4000);

            PlayerPrefs.SetInt(PREFS_WEAPON_NAME + 2, 1);
            PlayerPrefs.SetInt(PREFS_WEAPON_NAME + 3, 1);
            PlayerPrefs.SetInt(PREFS_WEAPON_NAME + 4, 1);
        }
    }
    #endregion

    [SerializeField]
    private GameObject[] _stagesPool;

    private Stack<GameObject> _stagesStack = new Stack<GameObject>();
    private const string
        PREFS_FIRST_LAUNCH = "FirstLaunch",
        PREFS_WEAPON_NAME = "Weapon",
        PREFS_UPGRADE_NAME = "Upgrade";

    private void Start()
    {
        _stagesStack.Push(_stagesPool[0]);
    }

    public void GoToStage(int index)
    {
        _stagesStack.Peek().SetActive(false);
        _stagesStack.Push(_stagesPool[index]);
        _stagesStack.Peek().SetActive(true);
    }

    public void GoToBack()
    {
        _stagesStack.Pop().SetActive(false);
        _stagesStack.Peek().SetActive(true);
    }
}

using System;
using TMPro;
using UnityEngine;

public class Translator : MonoBehaviour
{
    #region Singleton
    private static Translator _default;
    public static Translator Default => _default;
    #endregion

    private void Awake()
    {
        _default = this;
        ChangeLanguage();
    }

    public void Init(TMP_Text[] textFields, Lang[] pack)
    {
        this.textFields = textFields;
        this.pack = pack;
    }

    [Serializable]
    public struct Lang
    {
        public string[] desc;
    }

    [SerializeField] private TMP_Text[] textFields;
    [SerializeField] private Lang[] pack;

    public void SetLanguage(int index)
    {
        PlayerPrefs.SetInt("Language", index);

        ChangeLanguage();
    }
    
    private void ChangeLanguage()
    {
        int langPack = PlayerPrefs.GetInt("Language", 0);

        for (int i = 0; i < textFields.Length; i++)
        {
            textFields[i].text = pack[langPack].desc[i];
        }
    }
}

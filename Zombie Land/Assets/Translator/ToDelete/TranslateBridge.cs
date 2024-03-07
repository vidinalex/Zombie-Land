using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslateBridge : MonoBehaviour
{
    [SerializeField]
    private string[] IntBasedLangCode =
    {
        "en",
        "ru",
        "tr"
    };

    private TMP_Text[] tempTextFields, textFields;
    private List<TMP_Text> tempTextList = new List<TMP_Text>();
    private Translator.Lang[] pack;

    public void Replace()
    {
        TranslateRequest.IntBasedLangCode = IntBasedLangCode;
        tempTextFields = FindObjectsOfType<TMP_Text>(true);
        foreach(TMP_Text obj in tempTextFields)
        {
            IgnoreTranlation ignoreTranlation;
            obj.gameObject.TryGetComponent(out ignoreTranlation);
            if (!ignoreTranlation)
                tempTextList.Add(obj);
        }
        textFields = tempTextList.ToArray();
        pack = new Translator.Lang[TranslateRequest.IntBasedLangCode.Length];

        for (int i = 0; i < pack.Length; i++)
        {
            pack[i].desc = new string[textFields.Length];
        }

        for (int i = 0; i < textFields.Length; i++)
        {
            for (int j = 0; j < pack.Length; j++)
            {
                pack[j].desc[i] = TranslateRequest.Translate(textFields[i].text, TranslateRequest.IntBasedLangCode[0], j);
            }
        }

        gameObject.AddComponent<Translator>().Init(textFields, pack);
        DestroyImmediate(this);
    }
}

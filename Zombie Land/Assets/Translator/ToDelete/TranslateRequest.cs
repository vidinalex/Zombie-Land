using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AFMiniJSON;
using UnityEngine;
using UnityEngine.Networking;

public static class TranslateRequest
{
    public static string[] IntBasedLangCode;

    public static string Translate(string textToTranslate, string baseLanguage, int targetLanguageIndex)
    {
        return SendRequest(textToTranslate, baseLanguage, IntBasedLangCode[targetLanguageIndex]);
    }

    private static string SendRequest(string textToTranslate, string baseLanguageCode, string targetLanguageCode)
    {
        if (string.IsNullOrEmpty(textToTranslate))
        {
            Debug.Log("Null");
            return null;
        }
        var url = String.Format("https://translate.google.ru/translate_a/single?client=gtx&dt=t&sl={0}&tl={1}&q={2}",
            baseLanguageCode, targetLanguageCode, WebUtility.UrlEncode(textToTranslate));
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SendWebRequest();
        while (!www.isDone)
        {
        }
        string response = www.downloadHandler.text;

        return GetString(response);
    }

    private static string GetString(string response)
    {
        List<System.Object> test = Json.Deserialize(response) as List<System.Object>;

        var strings = GetAnswer(test).Where(node => node is string);

        foreach (var VARIABLE in strings)
        {
            return VARIABLE.ToString();
        }

        return null;
    }

    private static List<System.Object> GetAnswer(List<System.Object> defaultList)
    {
        List<System.Object> node = defaultList.Find(node => node is List<System.Object>) as List<System.Object>;
        List<System.Object> nodeSecond = node.Find(nodeSecond => nodeSecond is List<System.Object>) as List<System.Object>;

        return nodeSecond;
    }
}
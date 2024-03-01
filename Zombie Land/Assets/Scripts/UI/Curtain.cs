using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtain : MonoBehaviour
{
    public Action OnOpen, OnClose;

    [SerializeField]
    private float _actionDuration;

    private const float TARGET_END_SCALE = 10f;

    public void OpenCurtain()
    {
        StartCoroutine(COpenCurtain());
    }

    private IEnumerator COpenCurtain()
    {
        float timeElapsed = 0;

        transform.localScale = Vector3.zero;

        while (timeElapsed < _actionDuration)
        {
            transform.localScale = Vector3.one * Mathf.Lerp(0, TARGET_END_SCALE, timeElapsed / _actionDuration);
            timeElapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        OnOpen?.Invoke();
    }

    public void CloseCurtain()
    {
        StartCoroutine(CCloseCurtain());
    }

    private IEnumerator CCloseCurtain()
    {
        float timeElapsed = 0;

        transform.localScale = Vector3.one * TARGET_END_SCALE;

        while (timeElapsed < _actionDuration)
        {
            transform.localScale = Vector3.one * Mathf.Lerp(TARGET_END_SCALE, 0, timeElapsed / _actionDuration);
            timeElapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        transform.localScale = Vector3.zero;
        OnClose?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseOverScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private float _scaleFactor = 1.1f, _interpolationTime = 1;

    private Coroutine _currentCoroutine;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(CScale(Vector3.one * _scaleFactor));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(CScale(Vector3.one));
    }

    private IEnumerator CScale(Vector3 to)
    {
        float elapcedTime = 0;
        float interpolationRatio;

        while (transform.localScale != to)
        {
            interpolationRatio = elapcedTime / _interpolationTime;
            transform.localScale = Vector3.Lerp(transform.localScale, to, interpolationRatio);
            elapcedTime += Time.deltaTime;

            yield return null;
        }
    }
}

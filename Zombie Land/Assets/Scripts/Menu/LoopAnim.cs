using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAnim : MonoBehaviour
{
    [SerializeField]
    private float _fromScale = 1.1f, _toScale = 0.9f, _interpolationTime = 1;

    private void OnEnable()
    {
        StartCoroutine(CScale(_toScale * Vector3.one, _fromScale * Vector3.one));
    }

    private IEnumerator CScale(Vector3 from, Vector3 to)
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

        StartCoroutine(CScale(to, from));
    }
}

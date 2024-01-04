using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScalerAnim : MonoBehaviour
{
    [SerializeField]
    private float _interpolationTime = 1;

    private void OnEnable()
    {
        transform.localScale = Vector3.zero;

        StartCoroutine(CScale());
    }

    private IEnumerator CScale()
    {
        float elapcedTime = 0;
        float interpolationRatio;

        while(transform.localScale != Vector3.one)
        {
            interpolationRatio = elapcedTime / _interpolationTime;
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, interpolationRatio);
            elapcedTime += Time.deltaTime;

            yield return null;
        }
    }
}

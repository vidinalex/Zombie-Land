using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPopUpDMG : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _lifeTime, _yMod, _xMod;

    private float _currentLifeTime;

    public void SetUp(float dmg, bool isCrit)
    {
        _text.text = dmg.ToString();
    }
    private void OnEnable()
    {
        _currentLifeTime = _lifeTime;

        StartCoroutine(YieldMove());
    }

    private IEnumerator YieldMove()
    {
        float targetXMod = Random.Range(-_xMod, _xMod);

        while(_currentLifeTime > 0)
        {
            _currentLifeTime -= Time.deltaTime;
            _rectTransform.position += new Vector3(targetXMod, _yMod, 0) * Time.deltaTime;

            yield return null;
        }

        Destroy(gameObject);
    }
}

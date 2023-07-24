using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private float _reduceDelay, _decreaceMod;
    [SerializeField] private Image _actualHealthBar, _deltaHealthBar;

    private float _targetHealthDelay = 1;

    private void Update()
    {
        _deltaHealthBar.fillAmount = Mathf.Lerp(_deltaHealthBar.fillAmount, _targetHealthDelay, Time.deltaTime * _decreaceMod);
    }

    public void ReciveDMG(float _dmg, float _maxHP)
    {
        float delta = _dmg / _maxHP;
        _actualHealthBar.fillAmount -= delta;
        StartCoroutine(HealthReduceDelay(delta));
    }

    private IEnumerator HealthReduceDelay(float _delta)
    {
        yield return new WaitForSeconds(_reduceDelay);
        _targetHealthDelay -= _delta;
    }

    [ContextMenu("Recieve 23% HP")]
    private void TestRecieveDMG()
    {
        ReciveDMG(23, 100);
    }
}

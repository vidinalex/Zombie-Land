using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodOverlayManager : MonoBehaviour
{
    #region Singleton
    private static BloodOverlayManager _default;
    public static BloodOverlayManager Default => _default;

    private void Awake()
    {
        _default = this;
    }
    #endregion

    [SerializeField]
    private RawImage _overlayImage;
    [SerializeField]
    private float _fadeSpeed, _fadeDelay;

    private float _currentModifier = 0, _currentDelay;

    public void AddEffectMod(float mod)
    {
        _currentModifier += mod;
        _currentDelay = _fadeDelay;
    }

    private void Update()
    {
        _overlayImage.color = new Color(_overlayImage.color.r, _overlayImage.color.g, _overlayImage.color.b, _currentModifier);

        if (_currentDelay > 0)
        {
            _currentDelay -= Time.deltaTime;
            return;
        }

        if(_currentModifier > 0)
            _currentModifier -= _fadeSpeed * Time.deltaTime;
    }
}

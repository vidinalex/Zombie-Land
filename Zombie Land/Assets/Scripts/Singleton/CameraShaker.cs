using Cinemachine;
using System.Collections;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    #region Singleton
    private static CameraShaker _default;
    public static CameraShaker Default => _default;
    #endregion

    private void Awake()
    {
        _default = this;
    }

    [SerializeField] private CinemachineVirtualCamera _camera;

    private CinemachineBasicMultiChannelPerlin _noise;
    private IEnumerator _processShakeHolder;

    private void Start()
    {
        _noise = _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake(float frequency, float duration)
    {
        if (_processShakeHolder != null)
            StopCoroutine(_processShakeHolder);
        _processShakeHolder = ProcessShake(frequency, duration);
        StartCoroutine(_processShakeHolder);
    }

    private IEnumerator ProcessShake(float frequency, float duration)
    {
        _noise.m_FrequencyGain = frequency;
        yield return new WaitForSeconds(duration);
        _noise.m_FrequencyGain = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    private static AudioManager _default;
    public static AudioManager Default => _default;

    private void Awake()
    {
        _default = this;
    }
    #endregion

    [SerializeField]
    private AudioSource _fxInstance, _musicInstance;
    [SerializeField]
    private List<AudioClip> _audioPresets;

    public enum Presets : int
    {
        Hover,
        Click,
        MMenu,
        Game
    }

    public void PlaySoundFXAtPoint(AudioClip audioClip, Transform point)
    {
        AudioSource audioSource = Instantiate(_fxInstance, point.position, Quaternion.identity);
        audioSource.clip = audioClip;
        float clipLength = audioClip.length;
        Destroy(audioSource.gameObject, clipLength);

        audioSource.Play();
    }

    public void PlaySoundFXAtPoint(AudioClip[] audioClip, Transform point)
    {
        AudioSource audioSource = Instantiate(_fxInstance, point.position, Quaternion.identity);
        int rand = Random.Range(0, audioClip.Length);
        audioSource.clip = audioClip[rand];
        float clipLength = audioClip[rand].length;
        Destroy(audioSource.gameObject, clipLength);

        audioSource.Play();
    }

    private AudioSource audioSourceSingle;
    public void PlaySoundFXAtPointSingle(AudioClip audioClip, Transform point)
    {
        if (audioSourceSingle)
        {
            return;
        }
        audioSourceSingle = Instantiate(_fxInstance, point.position, Quaternion.identity);
        audioSourceSingle.clip = audioClip;
        float clipLength = audioClip.length;
        Destroy(audioSourceSingle.gameObject, clipLength);

        audioSourceSingle.Play();
    }

    public void DestroySingleSources()
    {
        if (audioSourceSingle)
        {
            Destroy(audioSourceSingle);
        }
    }

    public void PlaySoundFXPreset(Presets audioClip)
    {
        audioSourceSingle = Instantiate(_fxInstance, Camera.main.transform.position, Quaternion.identity);
        audioSourceSingle.clip = _audioPresets[(int)audioClip];
        float clipLength = _audioPresets[(int)audioClip].length;
        Destroy(audioSourceSingle.gameObject, clipLength);

        audioSourceSingle.Play();
    }

    public void PlayBGPreset(Presets audioClip)
    {
        AudioSource audioSource = Instantiate(_musicInstance, Camera.main.transform);
        audioSource.clip = _audioPresets[(int)audioClip];

        audioSource.Play();
    }
}

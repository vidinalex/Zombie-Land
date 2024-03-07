using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _langBGSelected;
    [SerializeField]
    private AudioMixer _audioMixer;
    [SerializeField]
    private Slider
        _musicSlider,
        _fxSlider;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        ApplyLang();
        ApplyMixer();

        _musicSlider.value = PlayerPrefs.GetFloat("MusicVol", 0.7f);
        _fxSlider.value = PlayerPrefs.GetFloat("FXVol", 0.7f);

        _musicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
        _fxSlider.onValueChanged.AddListener(OnFXSliderValueChanged);
    }

    public void SelectLang(int index)
    {
        PlayerPrefs.SetInt("Lang", index);

        ApplyLang();
    }

    private void ApplyLang()
    {
        foreach (GameObject go in _langBGSelected)
        {
            go.SetActive(false);
        }
        _langBGSelected[PlayerPrefs.GetInt("Lang", 0)].SetActive(true);
    }

    public void OnMusicSliderValueChanged(float value)
    {
        PlayerPrefs.SetFloat("MusicVol", value);
        ApplyMixer();
    }

    public void OnFXSliderValueChanged(float value)
    {
        PlayerPrefs.SetFloat("FXVol", value);
        ApplyMixer();
    }

    private void ApplyMixer()
    {
        _audioMixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("MusicVol", 0.7f)) * 20);
        _audioMixer.SetFloat("FXVol", Mathf.Log10(PlayerPrefs.GetFloat("FXVol", 0.7f)) * 20);
    }
}

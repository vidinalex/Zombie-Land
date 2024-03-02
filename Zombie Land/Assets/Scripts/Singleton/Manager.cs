using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    #region Singleton
    private static Manager _default;
    public static Manager Default => _default;
    #endregion

    [SerializeField] 
    private Camera _cameraMain;
    [SerializeField] 
    private Transform _plCharaTransform;
    [SerializeField]
    private Curtain 
        _curtain,
        _defeatCurtain;
    [SerializeField]
    private GameObject
        _pauseInterface,
        _defeatInterface,
        _winInterface;

    private bool _isPauseActive = false;

    private void Awake()
    {
        _default = this;

        if (_cameraMain == null)
            _cameraMain = Camera.main;
    }

    private void Start()
    {
        _curtain.CloseCurtain();
        _curtain.OnClose += ResumeTime;
        _defeatCurtain.OnOpen += PauseTime;
    }

    public Camera GetMainCamera()
    {
        return _cameraMain;
    }

    public Transform GetPlayerCharacterTransform()
    {
        return _plCharaTransform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }

    public void PauseMenu()
    {
        if (_isPauseActive)
        {
            _isPauseActive = false;

            _curtain.CloseCurtain();
            _pauseInterface.SetActive(false);
        }
        else
        {
            PauseTime();
            _isPauseActive = true;

            _curtain.OpenCurtain();
            _pauseInterface.SetActive(true);
        }
    }

    public void DefeatMenu()
    {
        _defeatCurtain.OpenCurtain();
        _defeatInterface.SetActive(true);
    }

    private void PauseTime()
    {
        Time.timeScale = 0;
    }

    private void ResumeTime()
    {
        Time.timeScale = 1;
    }

    public void GotoMenu()
    {
        ResumeTime();
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        ResumeTime();
        SceneManager.LoadScene(1);
    }

    public void WinMenu()
    {
        _curtain.OpenCurtain();
        _winInterface.SetActive(true);
    }
}
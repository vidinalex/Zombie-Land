using UnityEngine;

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
    private Curtain _curtain;
    [SerializeField]
    private GameObject _pauseInterface;

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
            if(_isPauseActive)
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
    }

    private void PauseTime()
    {
        Time.timeScale = 0;
    }

    private void ResumeTime()
    {
        Time.timeScale = 1;
    }
}

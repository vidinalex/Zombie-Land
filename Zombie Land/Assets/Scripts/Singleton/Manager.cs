using UnityEngine;

public class Manager : MonoBehaviour
{
    #region Singleton
    private static Manager _default;
    public static Manager Default => _default;
    #endregion

    [SerializeField] private Camera _cameraMain;

    private void Awake()
    {
        _default = this;

        if (_cameraMain == null)
            _cameraMain = Camera.main;
    }

    public Camera GetMainCamera()
    {
        return _cameraMain;
    }
}

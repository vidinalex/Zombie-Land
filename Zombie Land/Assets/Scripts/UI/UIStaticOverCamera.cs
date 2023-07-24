using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStaticOverCamera : MonoBehaviour
{
    private Camera _cameraMain;
    private void Start()
    {
        _cameraMain = Manager.Default.GetMainCamera();
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + _cameraMain.transform.rotation * Vector3.forward, _cameraMain.transform.rotation * Vector3.up);
    }
}

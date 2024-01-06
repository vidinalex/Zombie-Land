using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLookMouse : MonoBehaviour
{
    [SerializeField]
    private LayerMask _targetLayer;
    [SerializeField]
    private float _turnSpeed;

    private Camera _mCamera;

    private void Start()
    {
        _mCamera = Camera.main;
    }

    private void Update()
    {
        Ray ray = _mCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _targetLayer))
        {
            Vector3 targetPos = new Vector3(Mathf.Clamp(hit.point.x, -6, -2), Mathf.Clamp(hit.point.y, 0.5f, 2.5f), hit.point.z);
            Quaternion targetRotation = Quaternion.LookRotation(targetPos - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _turnSpeed * Time.deltaTime);
        }
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -90f);
    }
}

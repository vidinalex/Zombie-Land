using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponNegativeRotator : MonoBehaviour
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
            Vector3 targetPos = new Vector3(Mathf.Clamp(hit.point.x, -6, -2) + 2, Mathf.Clamp(hit.point.y, 0.5f, 2.5f) - 2, 0);
            Quaternion targetRotation = Quaternion.Euler(targetPos.y * 10, targetPos.x * 10, -10f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _turnSpeed * Time.deltaTime);
        }
    }
}
//-4 2
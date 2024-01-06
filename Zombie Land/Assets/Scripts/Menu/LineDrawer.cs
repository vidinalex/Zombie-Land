using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField]
    private RectTransform _p1, _p2;
    [SerializeField]
    private Transform _targetPos;

    private LineRenderer _lr;

    private void Start()
    {
        _lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        _lr.SetPosition(0, transform.position);
        _lr.SetPosition(1, _targetPos.position);

        _p1.position = transform.position;
        _p2.position = _targetPos.position;
    }
}

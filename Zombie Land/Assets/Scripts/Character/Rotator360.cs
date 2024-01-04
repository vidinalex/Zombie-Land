using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator360 : MonoBehaviour
{
    [SerializeField] private Vector3 _mVector;

    private void Update()
    {
        transform.Rotate(_mVector * Time.deltaTime);
    }
}

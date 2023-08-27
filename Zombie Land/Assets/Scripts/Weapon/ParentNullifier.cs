using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentNullifier : MonoBehaviour
{
    private void OnEnable()
    {
        transform.parent = null;
    }
}

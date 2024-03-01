using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelElement : MonoBehaviour
{
    [SerializeField]
    private GameObject
        _stateLocked,
        _stateNext,
        _stateUnlocked;

    public void SetLocked()
    {
        SetAllUnactive();
        _stateLocked.SetActive(true);
    }

    public void SetNext()
    {
        SetAllUnactive();
        _stateNext.SetActive(true);
    }

    public void SetUnlocked()
    {
        SetAllUnactive();
        _stateUnlocked.SetActive(true);
    }

    private void SetAllUnactive()
    {
        _stateLocked.SetActive(false);
        _stateNext.SetActive(false);
        _stateUnlocked.SetActive(false);
    }
}

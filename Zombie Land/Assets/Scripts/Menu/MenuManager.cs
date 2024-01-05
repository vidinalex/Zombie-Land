using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    #region Singleton
    private static MenuManager _default;
    public static MenuManager Default => _default;

    private void Awake()
    {
        _default = this;

        Application.targetFrameRate = 300;
    }
    #endregion

    [SerializeField]
    private GameObject[] _stagesPool;

    private Stack<GameObject> _stagesStack = new Stack<GameObject>();

    private void Start()
    {
        _stagesStack.Push(_stagesPool[0]);
    }

    public void GoToStage(int index)
    {
        _stagesStack.Peek().SetActive(false);
        _stagesStack.Push(_stagesPool[index]);
        _stagesStack.Peek().SetActive(true);
    }

    public void GoToBack()
    {
        _stagesStack.Pop().SetActive(false);
        _stagesStack.Peek().SetActive(true);
    }
}

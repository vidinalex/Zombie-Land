using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageShopController : MonoBehaviour
{
    [SerializeField]
    private ContentElement[] _contentElements;
    [SerializeField]
    private StageSkinController _stageSkinController;

    public void PickElement(int index)
    {
        for (int i = 0; i < _contentElements.Length; i++)
        {
            if(i == index)
            {
                _contentElements[i].ApplySkin(true);
            }
            else
            {
                _contentElements[i].ApplySkin(false);
            }
        }

        _stageSkinController.SetObservable(index+1);
    }

    public void BuyElement(int index)
    {
        MoneyMenuController.Default.UpdateMoney(-_contentElements[index]._cost);

        _contentElements[index].BuyElement();

        foreach (var element in _contentElements)
        {
            element.UpdateCurrentState();
        }
    }
}

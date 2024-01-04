using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWeaponManager : MonoBehaviour
{
    #region Singleton
    private static UIWeaponManager _default;
    public static UIWeaponManager Default => _default;

    private void Awake()
    {
        _default = this;
    }
    #endregion

    [SerializeField]
    private Image[] iconPool, fillPool;

    public void SetActiveWeapon(int index)
    {
        foreach(Image icon in iconPool)
        {
            icon.gameObject.SetActive(false);
        }

        iconPool[index].gameObject.SetActive(true);
    }

    public void UpdateFillAmount(int index, int ammoMax, int ammoCurrent)
    {
        float fillAmount = (float) ammoCurrent / ammoMax;
        fillPool[index].fillAmount = fillAmount;
    }
}

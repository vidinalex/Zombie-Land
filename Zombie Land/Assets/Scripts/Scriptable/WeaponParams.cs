using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponParams : ScriptableObject
{
    public int Index;

    public int InitialAmmoAmount;
    public int AmmoAmountMod;

    public int InitialDMG;
    public int DamageMod;

    public float _attackSpeed, _recoilStrength, _recoilDuration, _reciolFrequency;
}

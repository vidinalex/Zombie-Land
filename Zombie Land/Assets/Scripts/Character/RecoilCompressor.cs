using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RecoilCompressor : MonoBehaviour
{
    [SerializeField] private OverrideTransform _overrideRecoil;

    [SerializeField] private float _strength;

    private void Update()
    {
        _overrideRecoil.data.position = Vector3.Lerp(_overrideRecoil.data.position, Vector3.zero, Time.deltaTime * _strength);
    }

    public void AddRecoil(float recoilStrength)
    {
        _overrideRecoil.data.position = new Vector3(-recoilStrength, 0, 0);
    }
}

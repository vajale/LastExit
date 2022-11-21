using System;
using TMPro;
using UnityEngine;

public class PlayerUIView : MonoBehaviour
{
    [SerializeField] private TMP_Text _heath;
    [SerializeField] private TMP_Text _ammo;
    [SerializeField] private TMP_Text _currentWeapon;

    public Action OnViewDestroyed;

    public void SetAmmoInfo(float ammoCount, float magazineCapacity)
    {
        _ammo.text = ammoCount + "/" + magazineCapacity;
    }

    public void SetHealthInfo(float value)
    {
        _heath.text = "+" + value;
    }

    public void SetWeaponName(string name)
    {
        _currentWeapon.text = name;
    }

    private void OnDestroy()
    {
        OnViewDestroyed?.Invoke();
    }
}
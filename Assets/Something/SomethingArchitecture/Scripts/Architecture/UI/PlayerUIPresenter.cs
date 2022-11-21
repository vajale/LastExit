using Something.Scripts.Something.Weapon.Base;
using Something.SomethingArchitecture.Scripts.Architecture;

public class PlayerUIPresenter
{
    private PlayerUIView _view;
    private Player _model;
    private IWeaponModel _bruh;

    public PlayerUIPresenter(PlayerUIView view, ref Player model)
    {
        _view = view;
        _model = model;
    }

    private void FalseUpdate()
    {
        OnHealthChanged();
        OnWeaponSwitched();
    }

    public void Initialize()
    {
        _model.CurrentPlayableCharacter.Health.Changed += OnHealthChanged;
        _model.CurrentPlayableCharacter.WeaponInventory.CurrentWeapon.WeaponModel.AttackPerformed += OnAmmoChanged;
        _model.CurrentPlayableCharacter.WeaponInventory.CurrentWeapon.WeaponModel.MagazineReloaded += OnReloadWeapon;
        _model.CurrentPlayableCharacter.WeaponInventory.Switched += OnWeaponSwitched;
        _view.OnViewDestroyed += Uninitialize;
        
        FalseUpdate();
    }

    private void Uninitialize()
    {
        _model.CurrentPlayableCharacter.Health.Changed -= OnHealthChanged;
        _model.CurrentPlayableCharacter.WeaponInventory.CurrentWeapon.WeaponModel.AttackPerformed -= OnAmmoChanged;
        _model.CurrentPlayableCharacter.WeaponInventory.CurrentWeapon.WeaponModel.MagazineReloaded -= OnReloadWeapon;
        _model.CurrentPlayableCharacter.WeaponInventory.Switched -= OnWeaponSwitched;
        _view.OnViewDestroyed -= Uninitialize;
    }

    private void OnHealthChanged()
    {
        var value = _model.CurrentPlayableCharacter.Health.Count;
        _view.SetHealthInfo(value);
    }

    private void OnAmmoChanged(float ammoValue)
    {
        var currentWeapon = _model.CurrentPlayableCharacter.WeaponInventory.CurrentWeapon.WeaponModel;
        if (currentWeapon.CurrentWeaponMagazine == null)
        {
            _view.SetAmmoInfo(0, 0);
            return;
        }

        var ammoCount = currentWeapon.CurrentWeaponMagazine.Ammo;
        var magazineCapacity = currentWeapon.CurrentWeaponMagazine.MagazineCapacity;
        _view.SetAmmoInfo(ammoCount, magazineCapacity);
    }

    private void OnReloadWeapon(int value)
    {
        var currentWeapon = _model.CurrentPlayableCharacter.WeaponInventory.CurrentWeapon.WeaponModel;
        var ammoCount = currentWeapon.CurrentWeaponMagazine.Ammo;
        var magazineCapacity = currentWeapon.CurrentWeaponMagazine.MagazineCapacity;
        _view.SetAmmoInfo(ammoCount, magazineCapacity);
    }

    private void OnWeaponSwitched()
    {
        var weapon = _model.CurrentPlayableCharacter.WeaponInventory.CurrentWeapon;
        var weaponType = weapon.Type;

        _view.SetWeaponName(weaponType.ToString());
    }
}
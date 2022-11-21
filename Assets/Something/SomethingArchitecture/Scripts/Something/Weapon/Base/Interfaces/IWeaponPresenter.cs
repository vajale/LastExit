using Something.SomethingArchitecture.Scripts.Something.Weapon.Factory;

namespace Something.Scripts.Something.Weapon.Base
{
    public interface IWeaponPresenter
    {
        public IWeaponModel WeaponModel { get; }
        public IWeaponView View { get; }
        public WeaponTypeId Type { get; }
    }
}
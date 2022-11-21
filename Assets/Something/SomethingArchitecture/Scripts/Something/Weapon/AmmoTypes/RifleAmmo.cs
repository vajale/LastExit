using Something.Scripts.Something.Weapon.Base;

namespace Something.Scripts.Something.Weapon.AmmoTypes
{
    public class RifleAmmo : IAmmo
    {
        public int Damage
        {
            get { return 5; }
        }
    }
}
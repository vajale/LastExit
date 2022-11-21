using Something.Scripts.Something.Characters.UnitBody;
using UnityEngine;

namespace Something.Scripts.Something.Weapon.Base
{
    public class RaycastShootLogic : IShootLogic
    {
        public Vector3 LastShootLogic { get; private set; }

        private readonly float _spreadMultiplier;
        private readonly bool _useSpread;
        private readonly Transform _shootSource;
        private float _rayRange = 1000f;

        public RaycastShootLogic(float spreadMultiplier, bool useSpread, Transform shootSource)
        {
            _spreadMultiplier = spreadMultiplier;
            _useSpread = useSpread;
            _shootSource = shootSource;
        }
        
        public bool PerformShootOperation(IWeaponMagazine weaponMagazine)
        {
            var cameraForward = _shootSource.forward;
            var divisionSpread = Random.Range(-_spreadMultiplier / 50f, _spreadMultiplier / 50f);
            var forward = _useSpread ? cameraForward + GetSpread(divisionSpread) : cameraForward;

            if (Physics.Raycast(_shootSource.position, forward, out var hit, _rayRange))
            {
                LastShootLogic = hit.point;
                ScanAttackHit(hit, weaponMagazine);
                return true;
            }

            return false;
        }

        private void ScanAttackHit(RaycastHit hit, IWeaponMagazine weaponMagazine)
        {
            if (hit.collider.TryGetComponent(out IWeaponVisitor weaponVisitor))
            {
                Accept(weaponVisitor, weaponMagazine, hit);
            }
        }

        private Vector3 GetSpread(float spreadValue)
        {
            var shotDirectionAfterSpread = new Vector3();
            shotDirectionAfterSpread.x = Random.Range(0, spreadValue);
            shotDirectionAfterSpread.y = Random.Range(0, spreadValue);
            shotDirectionAfterSpread.z = Random.Range(0, spreadValue);

            return shotDirectionAfterSpread;
        }

        private void Accept(IWeaponVisitor weaponVisitor, IWeaponMagazine weaponMagazine, RaycastHit hit)
        {
            weaponVisitor.Visit(weaponMagazine.AmmoType, hit);
        }
    }
}
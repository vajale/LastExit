using Something.Scripts.Something.Characters.UnitBody;
using UnityEngine;

namespace Something.Scripts.Something.Characters.Enemy.Weapon.Model
{
    public class EnemyRaycastGunModel
    {
        public float Damage => 5f;
        
        public bool PerformWeaponRaycast(Transform source,float spreadMultiplier, bool useSpread)
        {
            var cameraForward = source.forward;
            var divisionSpread = Random.Range(-spreadMultiplier / 50f, spreadMultiplier / 50f);
            var forward = useSpread ? cameraForward + ApplySpread(divisionSpread) : cameraForward;

            if (Physics.Raycast(source.position, forward, out var hit, 900f))
            {
                ScanAttackHit(hit);
                return true;
            }

            return false;
        }

        private Vector3 ApplySpread(float spreadValue)
        {
            var shotDirectionAfterSpead = new Vector3();
            shotDirectionAfterSpead.x = Random.Range(0, spreadValue);
            shotDirectionAfterSpead.y = Random.Range(0, spreadValue);
            shotDirectionAfterSpead.z = Random.Range(0, spreadValue);

            return shotDirectionAfterSpead;
        }
        
        private void ScanAttackHit(RaycastHit hit)
        {
            if (hit.collider.TryGetComponent(out IWeaponVisitor weaponVisitor))
            {
                Accept(weaponVisitor, hit);
            }
        }
        
        public void Accept(IWeaponVisitor weaponVisitor, RaycastHit hit)
        {
            //weaponVisitor.Visit(this, hit);
        }
        
    }
}
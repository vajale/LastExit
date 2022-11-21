using UnityEngine;

namespace Something.Scripts.Something.Characters.Enemy.Weapon.Model
{
    public class EnemyMeleeModel
    {
        private float _melleDamage = 20f;
        
        private void TryPerformAttack(Transform source, float offset, float radius)
        {
            var forwardOffset = Vector3.forward * offset;
            var colliders = Physics.OverlapSphere(source.position + forwardOffset, radius);

            foreach (var other in colliders)
            {

            }
        }
    }
}
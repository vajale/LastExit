using Something.SomethingArchitecture.Scripts.Something.Characters.Base;
using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Architecture.Factory
{
    public enum LootType
    {
        Ammo = 1,
        Health = 2
    }

    public class Loot : MonoBehaviour, ILoot
    {
        [SerializeField] private LootType _lootType;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layer;
        [SerializeField] private float _smoothValue;


        private void FixedUpdate()
        {
            SearchPlayer();
        }

        private void SearchPlayer()
        {
            var colliders = Physics.OverlapSphere(transform.position, _radius);

            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out IPlayableCharacterView component))
                {
                    GoToPlayer(component.transform);

                    float dist = Vector3.Distance(component.transform.position, transform.position);
                    if (dist < 1f)
                    {
                        switch (_lootType)
                        {
                            case LootType.Health:
                                component.CharacterModel.Health.Recove(7);
                                break;
                            case LootType.Ammo:
                                var weaponType = component.CharacterModel.WeaponInventory.CurrentWeapon.Type;
                                var inventory = component.CharacterModel.WeaponInventory;
                                inventory.AddMagazine(weaponType);
                                break;
                        }
                        
                        Destroy(gameObject);
                    }
                }
            }
        }

        private void GoToPlayer(Transform target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, _smoothValue);
            transform.LookAt(target);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}
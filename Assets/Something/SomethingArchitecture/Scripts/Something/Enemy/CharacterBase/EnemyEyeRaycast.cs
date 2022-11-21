using Something.SomethingArchitecture.Scripts.Something.Characters.Base;
using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Something.Characters.Enemy
{
    public class EnemyEyeRaycast : MonoBehaviour
    {
        [SerializeField] private LayerMask LayerMask;

        public bool FindSomething(float distance, out RaycastHit hit)
        {
            var origin = transform.position;
            var result = Physics.Raycast(origin, Vector3.forward, out var hitInfo, distance);
            hit = hitInfo;

            return result;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var origin = transform.position;
            var forward = transform.forward;
            Gizmos.DrawRay(origin, forward);
        }
    }
}
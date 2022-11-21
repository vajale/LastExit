using Something.SomethingArchitecture.Scripts.Architecture.Data;
using Something.SomethingArchitecture.Scripts.Architecture.Data.ID;
using UnityEngine;

namespace Something.Scripts.Architecture.Data
{
    [CreateAssetMenu(menuName = "Create EnemyCharacterData", fileName = "EnemyCharacterData", order = 0)]
    public class EnemyCharacterData : ScriptableObject, ICharacterData
    {
        #region Data Fields

        [Header("ID")] [SerializeField] private EnemyCharacterID _id;

        [Header("Attack Settings")] 
        [SerializeField] private float attackDuration;

        [Header("Movement")]
        [SerializeField] private float startHealthCount;
        [SerializeField] private float walkSpeed = 2f;
        [SerializeField] private float crouchSpeed = 1f;
        [SerializeField] private float runSpeed = 3f;
        [SerializeField] private float jumpSpeed = 5f;

        [Header("Gravity")]
        [SerializeField] private float gravityMultiplier = 2.5f;

        #endregion

        #region CharacterPreFabModel

        [Header("Character PreFab")] [SerializeField]
        private GameObject preFab;

        #endregion

        #region Public Field

        public GameObject PreFab => preFab;
        public EnemyCharacterID ID => _id;
        public float HealthPointCount => startHealthCount;
        public float WalkSpeed => walkSpeed;
        public float RunSpeed => runSpeed;
        public float JumpSpeed => jumpSpeed;

        #endregion
    }
}
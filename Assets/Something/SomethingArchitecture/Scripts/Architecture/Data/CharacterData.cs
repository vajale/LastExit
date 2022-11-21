using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Architecture.Data
{
    [CreateAssetMenu(menuName = "Create CharacterData", fileName = "CharacterData", order = 0)]
    public class CharacterData : ScriptableObject, ICharacterData
    {
        #region Data Fields

        [Header("Movement")] [SerializeField] private float startHealthCount;
        [SerializeField] private float walkSpeed = 2f;
        [SerializeField] private float crouchSpeed = 1f;
        [SerializeField] private float runSpeed = 3f;
        [SerializeField] private float jumpSpeed = 5f;

        [Header("Gravity")] 
        [SerializeField] private float gravityMultiplier = 2.5f;

        #endregion

        #region CharacterPreFabModel

        [Header("Character PreFab")]
        [SerializeField] private GameObject preFab;

        #endregion

        #region Public Field

        public GameObject PreFab => preFab;
        public float HealthPointCount => startHealthCount;
        public float WalkSpeed => walkSpeed;
        public float RunSpeed => runSpeed;
        public float JumpSpeed => jumpSpeed;
        public float GravityMultiplier => gravityMultiplier;

        #endregion
    }
}
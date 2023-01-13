using Something.Scripts.Something.AI;
using Something.Scripts.Something.Characters;
using Something.SomethingArchitecture.Scripts.Something.Characters.Base;
using Something.SomethingArchitecture.Scripts.Something.Characters.Enemy;
using UnityEngine;

namespace Something.Scripts.Something.EnemyWave
{
    public class SearchTargetCommand : ICommand 
    {
        private readonly EnemyCharacter _character;
        private float _searchRadius;

        public SearchTargetCommand(EnemyCharacter character)
        {
            _character = character;
            _searchRadius = 20f;
        }

        public void Execute()
        {
            SearchTarget();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Undo()
        {
        }

        private IPlayableCharacter SearchTarget()
        {
            var targets = Physics.OverlapSphere(_character.Mover.transform.position, _searchRadius);

            foreach (var target in targets)
            {
                if (target.TryGetComponent<IPlayableCharacterView>(out var component))
                {
                    _character.SetCommand(new ChaseCommand(component.CharacterModel, _character));
                }
            }

            return null;
        }
    }
}
using System;
using Something.Scripts.Something.Characters;
using Something.SomethingArchitecture.Scripts.Architecture.Data;
using Something.SomethingArchitecture.Scripts.Architecture.Data.ID;
using Something.SomethingArchitecture.Scripts.Architecture.Factory.Interface;
using Something.SomethingArchitecture.Scripts.Something.Characters.Base;
using Something.SomethingArchitecture.Scripts.Something.Characters.MoveControllers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SomethingArchitecture.Scripts.Architecture.Factory
{
    public class CharacterFactory : ICharacterFactory
    {
        private bool _isPlayerCharacterInstantiated;

        public PlayerCharacterView CreatePlayerCharacter(Vector3 position, CharacterData data,
            out PlayerCharacterModel playerCharacterModel)
        {
            if (_isPlayerCharacterInstantiated)
                throw new Exception("Player character has already been instantiated");

            var characterInstance = Object.Instantiate(data.PreFab, position, Quaternion.identity);

            characterInstance.TryGetComponent(out PlayerCharacterView characterView);
            if (characterView == null)
                throw new Exception("The character player's prefab has no component found CharacterView!");

            characterView.TryGetComponent(out CharacterController characterControllerComponent);
            if (characterControllerComponent == null)
                throw new Exception("CharacterView not contains CharacterController component");

            characterInstance.TryGetComponent(out EnemyUnitBodyPresenter unitBodyComponent);
            if (unitBodyComponent == null)
                throw new Exception("CharacterInstance not contains UnitBodyComponent component");

            var health = new Health(data.HealthPointCount);
            var unitBody = new UnitBody(health, unitBodyComponent);
            var moveController = new StandartMoveController(data, characterControllerComponent);
            var character = new PlayerCharacterModel(unitBody, moveController);

            playerCharacterModel = character;
            characterView.InitializeModel(playerCharacterModel);
            character.SetCamera(characterView.CameraTransform);
            
            _isPlayerCharacterInstantiated = true;

            return characterView;
        }
    }
    
}
using System;
using Something.Scripts.Architecture.GameInfrastucture;
using Something.SomethingArchitecture.Scripts.Something.Characters.Base;
using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Something
{
    public abstract class GameLoopScript : MonoBehaviour
    {
        protected IGamePlayServiceHelper gamePlayService;

        public void Initialize(IGamePlayServiceHelper gameplayService)
        {
            this.gamePlayService = gameplayService;
            
        }

        protected bool CheckIfPlayer(Collider collider, out PlayerCharacterView playerCharacterView)
        {
            var flag = collider.TryGetComponent(out PlayerCharacterView characterView);
            playerCharacterView = characterView;

            return flag;
        }
        
        protected bool CheckIfPlayer(Collider collider)
        {
            var flag = collider.TryGetComponent(out PlayerCharacterView characterView);
            return flag;
        }

        protected abstract void Execute();
    }
}
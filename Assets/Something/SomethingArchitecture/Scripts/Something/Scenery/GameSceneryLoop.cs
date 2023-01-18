using System;
using System.Collections.Generic;
using Something.SomethingArchitecture.Scripts.Architecture.GameInfrastucture.States;
using Something.SomethingArchitecture.Scripts.Something;

namespace Something.Scripts.Architecture.GameInfrastucture
{
    public class GameSceneryLoop
    {
        private readonly GameplayService _gameplayService;
        private List<Lever> _levers;
        private List<GameLoopScript> _loopScripts;

        public bool IsEnded { get; private set; }
        public event Action Ended;

        public GameSceneryLoop(GameplayService gameplayService)
        {
            _gameplayService = gameplayService;
            _levers = new List<Lever>();
        }

        public void Initialize(List<Lever> levers, List<GameLoopScript> loopScripts)
        {
            foreach (var lever in levers)
            {
                lever.Switched += CheckState;
            }

            foreach (var script in loopScripts)
            {
                script.Initialize(_gameplayService);
            }
        }

        private void CheckState()
        {
            int countSwitchedOfLevers = 0;
            
            foreach (var lever in _levers)
            {
                if (lever.IsSwitched)
                {
                    countSwitchedOfLevers++;
                }
            }

            if (countSwitchedOfLevers == _levers.Count)
            {
                IsEnded = true;
                Ended.Invoke();
            }
            else
            {
                IsEnded = false;
            }
        }
    }
}
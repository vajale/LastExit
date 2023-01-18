using System.Collections.Generic;

namespace Something.SomethingArchitecture.Scripts.Architecture.GameInfrastucture.States
{
    public class GameSceneryLoop
    {
        public bool IsEnded;

        private List<Lever> _levers;

        public GameSceneryLoop()
        {
            _levers = new List<Lever>();
        }

        public void Initialize(List<Lever> levers)
        {
            foreach (var lever in levers)
            {
                _levers.Add(lever);
                lever.Switched += CheckState;
            }
        }

        private void CheckState()
        {
            var leversCount = _levers.Count;
            int switchedLevers = 0;

            foreach (var lever in _levers)
            {
                if (lever.IsSwitched)
                    switchedLevers++;
            }

            IsEnded = switchedLevers == leversCount;
        }
    }
}
using System;
using Something.Scripts.Architecture.Services.ServiceLocator;

namespace Something.Scripts.Architecture.Utilities
{
    public class SaveLoadService : IService
    {
        private PlayerProgress _currentProgress;

        public SaveLoadService()
        {
        }

        public void SetProgress(ref PlayerProgress progress)
        {
            _currentProgress = progress;
        }

        public void LoadProgress(bool solidLoad = false)
        {
            if (_currentProgress == null)
            {
                throw new Exception("Load " + _currentProgress + " is failed");
            }
            else
            {
                var saveList = _currentProgress.GetSaveables();
                foreach (var saveable in saveList)
                {
                    saveable.LoadProgress(_currentProgress);
                }
            }
        }

        public void UpdateProgress()
        {
            if (_currentProgress == null)
            {
                _currentProgress = new PlayerProgress();
            }
            else
            {
                var list = _currentProgress.GetSaveables();
                foreach (var saveable in list)
                {
                    saveable.UpdateProgress(_currentProgress);
                }
            }
        }
    }
}
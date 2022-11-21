namespace Something.Scripts.Architecture.Utilities
{
    public interface ISaveable
    {
        void LoadProgress(IPlayerProgress playerProgress);
        void UpdateProgress(IPlayerProgress playerProgress);
    }
}
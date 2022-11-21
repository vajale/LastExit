namespace Something.Scripts.Architecture.GameInfrastucture.States.Interfaces
{
    public interface ILoadedState<T> : IExitableState
    {
        void Enter(T payload);
    }
}
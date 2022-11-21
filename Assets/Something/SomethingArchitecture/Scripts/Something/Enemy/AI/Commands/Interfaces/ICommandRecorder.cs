namespace Something.Scripts.Something.AI
{
    public interface ICommandRecorder
    {
        void Record(ICommand command);
        void Undo();
    }
}
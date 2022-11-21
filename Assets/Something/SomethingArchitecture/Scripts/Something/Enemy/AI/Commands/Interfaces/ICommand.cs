namespace Something.Scripts.Something.AI
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
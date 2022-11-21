using System.Collections.Generic;

namespace Something.Scripts.Something.AI
{
    public class EnemyCommandRecorder : ICommandRecorder
    {
        public ICommand Current { get; private set; }
        private Stack<ICommand> _commands;

        public EnemyCommandRecorder()
        {
            _commands = new Stack<ICommand>();
        }

        public void Record(ICommand command)
        {
            _commands.Push(command);
            command.Execute();
        }

        public void Undo()
        {
            if (_commands.Count == 0)
                return;
            
            var undoCommand = _commands.Pop();
            undoCommand.Undo();
        }
    }
}
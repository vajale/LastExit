using Something.Scripts.Something.Characters;

namespace Something.Scripts.Something.AI
{
    public interface IEnemyAI
    {
        void UpdateProgress();
        void SetCommand(ICommand command);
        void SwitchTarget(IPlayableCharacter playableCharacter);
    }
}
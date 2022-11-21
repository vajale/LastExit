using Something.Scripts.Something.Characters.MoveControllers;
using Something.SomethingArchitecture.Scripts.Something.Characters.Base;

namespace Something.Scripts.Something.Characters
{
    public interface IPlayableCharacter
    {
        Health Health { get; }
        IWeaponInteract WeaponInventory { get; }
        IPlayerMoveController MoveController { get; }
    }
}
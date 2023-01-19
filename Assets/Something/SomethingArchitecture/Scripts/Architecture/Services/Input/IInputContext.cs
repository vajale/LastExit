using System.Numerics;
using Something.Scripts.Something.Characters;

namespace Something.Scripts.Something
{
    public interface IInputContext
    {
        Vector2 Axis { get; }

        bool Interact { get; }
        bool WeaponInteractInvoke { get; }
        bool WeaponInteractInvoke2 { get; }
        bool WeaponReloadInteract { get; }

        float MouseScrollWheel { get; }
        bool JumpButton { get; }
    }
}
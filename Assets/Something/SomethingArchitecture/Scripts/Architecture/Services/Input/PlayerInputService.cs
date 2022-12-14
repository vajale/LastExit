using Something.Scripts.Architecture.Services.ServiceLocator;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace Something.Scripts.Architecture.Services
{
    public class PlayerInputService : IInputService
    {
        public Vector2 Axis => inputAxis;
        public bool RightMouseButton => Input.GetKeyDown(KeyCode.Mouse0);
        public bool LeftMouseButton => Input.GetKeyDown(KeyCode.Mouse1);
        public bool ReloadButton => Input.GetKeyDown(KeyCode.R);
        private Vector2 inputAxis => new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
            
        public float MouseScrollWheel => Input.GetAxisRaw("Mouse ScrollWheel");

    }

    public interface IInputService : IService
    {
        Vector2 Axis { get; }
        bool RightMouseButton { get; }
        bool LeftMouseButton { get; }
        bool ReloadButton { get; }
        float MouseScrollWheel { get; }
    }
}
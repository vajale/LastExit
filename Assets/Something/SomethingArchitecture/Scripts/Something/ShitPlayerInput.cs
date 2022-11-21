using UnityEngine;

namespace Something.Scripts.Something
{
    public class ShitPlayerInput : MonoBehaviour
    {
        public float MouseX { get; private set; }
        public float MouseY { get; private set; }
        public static float AxisY { get; private set; }
        public static float AxisX { get; private set; }

        public  bool IsRightMouseClick { get; private set; }
        public  bool IsRightMouseButtonDown { get; private set; }
        public  bool IsRightMouseButtonUp { get; private set; }

        public  bool IsLeftMouseClick { get; private set; }
        public  bool IsLeftMouseButtonDown { get; private set; }
        public  bool IsLeftMouseButtonUp { get; private set; }

        public static bool IsShiftClicked { get; private set; }
        public static bool IsShiftReleased { get; private set; }
        public static bool IsJumpCllicked { get; private set; }
        public  bool IsReloadButtonDown { get; private set; }

        private void Update()
        {
            UpdateInputData();
        }

        public void UpdateInputData()
        {
            AxisX = Input.GetAxis("Horizontal");
            AxisY = Input.GetAxis("Vertical");
        
            MouseX = Input.GetAxis("Mouse X");
            MouseY = Input.GetAxis("Mouse Y");

            IsRightMouseClick = Input.GetKey(KeyCode.Mouse0);
            IsRightMouseButtonDown = Input.GetKeyDown(KeyCode.Mouse0);
            IsRightMouseButtonUp = Input.GetKeyUp(KeyCode.Mouse0);
        
            IsLeftMouseClick = Input.GetKey(KeyCode.Mouse1);
            IsLeftMouseButtonDown = Input.GetKeyDown(KeyCode.Mouse1);
            IsLeftMouseButtonUp = Input.GetKeyUp(KeyCode.Mouse1);

            IsReloadButtonDown = Input.GetKeyDown(KeyCode.R);
            IsShiftClicked = Input.GetKey(KeyCode.LeftShift);
            IsShiftReleased = Input.GetKeyUp(KeyCode.LeftShift);
            IsJumpCllicked = Input.GetKeyDown(KeyCode.Space);
        }
    }
}


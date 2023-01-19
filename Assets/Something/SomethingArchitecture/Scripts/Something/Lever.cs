using System;
using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Architecture.GameInfrastucture.States
{
    public class Lever : MonoBehaviour, ITouchable
    {
        [SerializeField] private Light _indicator;

        private bool _isSwitched;
        public bool IsSwitched => _isSwitched;
        public event Action Switched;

        private void Switch() =>
            _isSwitched = !_isSwitched;

        private void Start()
        {
            SwitchLight();
        }

        public void Touch()
        {
            Switch();
            Debug.Log("Lever is switched");
            
            SwitchLight();
        }

        private void SwitchLight()
        {
            if (_isSwitched)
                _indicator.color = Color.green;
            else
                _indicator.color = Color.red;
        }
    }

    public interface ITouchable
    {
        void Touch();
    }
}
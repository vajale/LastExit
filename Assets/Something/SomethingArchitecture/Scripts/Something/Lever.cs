using System;
using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Architecture.GameInfrastucture.States
{
    public class Lever : MonoBehaviour, ITouchable
    {
        private bool _isSwitched;
        public bool IsSwitched => _isSwitched;
        public event Action Switched;

        private void Switch() => 
            _isSwitched = !_isSwitched;

        public void Touch()
        {
            Switch();
            Debug.Log("Lever is switched");
        }
    }

    public interface ITouchable
    {
        void Touch();
    }
}
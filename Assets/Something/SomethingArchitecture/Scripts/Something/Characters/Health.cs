using System;
using Something.Scripts.Architecture.Utilities;
using UnityEngine;

namespace Something.Scripts.Something.Characters
{
    public class Health
    {
        public float Count { get; private set; }
        public Action Changed { get; set; }
        public Action Ended { get; set; }

        public Health(float heathValue)
        {
            if (heathValue < 0)
                throw new InvalidOperationException("Invalid health value");

            Count = heathValue;
        }

        public void TakeDamage(float value)
        {
            if (value < 0)
                throw new InvalidOperationException("Invalid damage value");

            Count -= value;
            Changed?.Invoke();

            if (Count <= 0)
            {
                Ended?.Invoke();
                Count = 0;
            }
        }

        public void Recove(float value)
        {
            if (value <= 0)
                throw new InvalidOperationException("Invalid recove value");

            Count += value;
            Changed?.Invoke();
        }

        public void SetCount(IPlayerProgress progress)
        {
            var newValue = progress.HeathProgress.Count;

            if (newValue > 0)
            {
                Count = newValue;
                Changed?.Invoke();
            }
        }
    }
}
using Something.Scripts.Something.Characters;
using UnityEngine;

namespace Something.Scripts.Architecture.Utilities
{
    public class CharacterProgress
    {
        public Health Health { get; set; }
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; private set; }
    }
}
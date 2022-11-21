using UnityEngine;

namespace Something.SomethingArchitecture.Scripts.Architecture.Factory.Interface
{
    public interface IPlayerUIFactory
    {
        PlayerUIView CreateBaseUI(ref Player model, GameObject gameObject);
    }
}
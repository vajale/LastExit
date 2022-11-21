using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Something.SomethingArchitecture.Scripts.Architecture.Factory.Interface
{
    public class PlayerUIFactory : IPlayerUIFactory
    {
        public PlayerUIView CreateBaseUI(ref Player model, GameObject gameObject)
        {
            var maybeView = Object.Instantiate(gameObject);

            maybeView.TryGetComponent(out PlayerUIView viewComponent);
            if (viewComponent == null)
                throw new Exception("PlayerUIView component is missing or not contains");

            var presenter = new PlayerUIPresenter(viewComponent, ref model);
            presenter.Initialize();

            return viewComponent;
        }
    }
}
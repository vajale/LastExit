using System;
using System.Collections.Generic;

namespace Something.Scripts.Architecture.Services.ServiceLocator
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, IService> _services;

        static ServiceLocator()
        {
            _services = new Dictionary<Type, IService>();
        }

        public static void Register<TService>(TService service) where TService : IService
        {
            _services[typeof(TService)] = service;
        }

        public static TService GetService<TService>() where TService : IService
        {
            var type = typeof(TService);
            _services.TryGetValue(type, out var foundedService);

            return (TService) foundedService;
        }

        public static void Remove<TService>() where TService : IService
        {
            var type = typeof(TService);

            if (_services.ContainsKey(type))
                _services.Remove(type);
        }
    }
}
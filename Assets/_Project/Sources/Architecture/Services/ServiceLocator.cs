using System;
using System.Collections.Generic;

namespace Sources.Architecture.Services
{
    public class ServiceLocator : IServiceLocator
    {
        public static ServiceLocator Instance { get; private set; }

        protected Dictionary<Type, object> ItemsMap { get; private set; }

        public ServiceLocator()
        {
            Instance = this;

            ItemsMap = new Dictionary<Type, object>();
        }

        public T Register<T>(T newService)
        {
            var type = typeof(T);

            if (ItemsMap.ContainsKey(type))
            {
                throw new Exception($"Cannot add item of type {type}. This type already exists.");
            }

            ItemsMap[type] = newService;
            return newService;
        }

        public void Unregister<T>()
        {
            var type = typeof(T);
            ItemsMap.Remove(type);
        }

        public T Get<T>()
        {
            var type = typeof(T);

            if (!ItemsMap.TryGetValue(type, out var service))
            {
                throw new Exception($"There is no object with type {type}.");
            }

            return (T)service;
        }
    }
}
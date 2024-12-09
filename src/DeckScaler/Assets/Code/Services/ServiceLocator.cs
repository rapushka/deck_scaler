using System;
using DeckScaler.Service;
using UnityEngine;

namespace DeckScaler
{
    public static class ServiceLocator
    {
        public static void Setup<TService>(TService service) where TService : IService
            => Service<TService>.Instance = service;

        public static T Get<T>()
            where T : IService
        {
            return Service<T>.Instance;
        }

        private static class Service<T>
            where T : IService
        {
            private static T _instance;

            public static T Instance
            {
                get => _instance ?? throw new InvalidOperationException($"the {typeof(T).Name} Service isn't initialized!");
                set => _instance = value ?? throw new NullReferenceException();
            }
        }

        [Serializable]
        public class Data
        {
            [field: SerializeField] public Cameras.Data CamerasData { get; private set; }
            [field: SerializeField] public Configs      Configs     { get; private set; }
        }
    }
}
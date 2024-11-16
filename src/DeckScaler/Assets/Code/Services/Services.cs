using System;
using DeckScaler.Service;
using UnityEngine;

namespace DeckScaler
{
    public static class Services
    {
        public static void Init(GameStateMachine stateMachine, Data data)
        {
            Service<UI>.Instance = new UI();
            Service<Cameras>.Instance = new Cameras(data);
            Service<GameStateMachine>.Instance = stateMachine;
            Service<Ecs>.Instance = new Ecs();
            Service<Configs>.Instance = data.Configs;
            Service<Progress>.Instance = new Progress();
            Service<Factories>.Instance = new Factories();

            InitDebugServices();
        }

        private static void InitDebugServices()
        {
#if DEBUG
            Service<IDebug>.Instance = new SimpleDebug();
#else
            Service<IDebug>.Instance = new DebugMock();
#endif
        }

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
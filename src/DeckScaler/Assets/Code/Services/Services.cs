using DeckScaler.Service;
using UnityEngine;

namespace DeckScaler
{
    public static class Services
    {
        public static void Init
        (
            GameStateMachine gameStateMachine,
            Cameras.Data camerasData,
            Configs configs
        )
        {
            Service<UI>.Instance = new UI();
            Service<Cameras>.Instance = new Cameras(camerasData);
            Service<GameStateMachine>.Instance = gameStateMachine;
            Service<Ecs>.Instance = new Ecs();
            Service<Configs>.Instance = configs;
            Service<ProgressData>.Instance = new ProgressData();
            Service<Factories>.Instance = new Factories();
        }

        public static T Get<T>() where T : IService
        {
#if DEBUG
            if (Service<T>.Instance is null)
                Debug.LogError($"the {typeof(T).Name} Service isn't initialized!");
#endif

            return Service<T>.Instance;
        }

        private static class Service<T>
        {
            public static T Instance;
        }
    }
}
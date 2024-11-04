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
            Service<Progress>.Instance = new Progress();
            Service<EventBus>.Instance = new EventBus();
        }

        public static T Get<T>()
            where T : IService
        {
#if DEBUG
            if (Service<T>.Instance is null)
                Debug.LogError($"the {typeof(T).Name} Service isn't initialized!");
#endif

            return Service<T>.Instance;
        }

        private static class Service<T>
            where T : IService
        {
            public static T Instance;
        }
    }
}
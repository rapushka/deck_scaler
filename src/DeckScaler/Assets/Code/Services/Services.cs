using DeckScaler.Service;
using UnityEngine;
using Debug = DeckScaler.Service.Debug;

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

#if DEBUG
            Service<IDebug>.Instance = new Debug();
#else
            Service<IDebug>.Instance = new DebugMock();
#endif
        }

        public static T Get<T>()
            where T : IService
        {
#if DEBUG
            if (Service<T>.Instance is null)
                UnityEngine.Debug.LogError($"the {typeof(T).Name} Service isn't initialized!");
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
using DeckScaler.Service;

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
        }

        public static T Get<T>() where T : IService => Service<T>.Instance;

        private static class Service<T>
        {
            public static T Instance;
        }
    }
}
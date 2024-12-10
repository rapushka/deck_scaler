using DeckScaler.Service;

namespace DeckScaler
{
    public class InitializeServicesState : GameState, IPayload<IConfigs>
    {
        private IConfigs _configs;

        public void SetData(IConfigs configs)
        {
            _configs = configs;
        }

        public override void Enter()
        {
            // ReSharper disable RedundantTypeArgumentsOfMethod - I wanna keep consistency here

            ServiceLocator.Register<IConfigs>(_configs);
            ServiceLocator.Register<IUiScreens>(new UiScreens());
            ServiceLocator.Register<ICameras>(_configs.Cameras);
            ServiceLocator.Register<IEcs>(new Ecs());
            ServiceLocator.Register<IProgress>(new Progress());
            ServiceLocator.Register<IFactories>(new Factories());
            ServiceLocator.Register<IRandom>(new SimpleRandom());
            ServiceLocator.Register<IUiMediator>(new UiMediator());
            ServiceLocator.Register<ITime>(new SimpleTime());
            ServiceLocator.Register<IInput>(new UnityInput());
            ServiceLocator.Register<IUtils>(new Utils());
            ServiceLocator.Register<IIdentifierServer>(new IdentifierServer());

            var ecsRunner = new EcsRunner();
            ServiceLocator.Register<IEcsRunner>(ecsRunner);

            SetupDebugServices();
            InitializeManualUpdater(
                ecsRunner
            );

            StateMachine.Enter<BootstrapState>();
        }

        private void InitializeManualUpdater(params IUpdatable[] services)
        {
            var updater = new ManualUpdater();
            ServiceLocator.Register<IManualUpdater>(updater);
            updater.Initialize(services);
        }

        private void SetupDebugServices()
        {
#if DEBUG
            ServiceLocator.Register<IDebug>(new SimpleDebug());
#else
            ServiceLocator.Register<IDebug>(new DebugMock());
#endif
        }
    }
}
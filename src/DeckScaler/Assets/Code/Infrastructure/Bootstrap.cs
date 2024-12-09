using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private ServiceLocator.Data _servicesData;

        private void Awake()
        {
            InitializeEcs();

            var gameStateMachine = new GameStateMachine();

            ServiceLocator.Register<IUI>(new UI());
            ServiceLocator.Register<ICameras>(new Cameras(_servicesData));
            ServiceLocator.Register<IGameStateMachine>(gameStateMachine);
            ServiceLocator.Register<IEcs>(new Ecs());
            ServiceLocator.Register<IConfigs>(_servicesData.Configs);
            ServiceLocator.Register<IProgress>(new Progress());
            ServiceLocator.Register<IFactories>(new Factories());
            ServiceLocator.Register<IRandom>(new SimpleRandom());
            ServiceLocator.Register<IUiMediator>(new UiMediator());
            ServiceLocator.Register<ITime>(new SimpleTime());
            ServiceLocator.Register<IInput>(new UnityInput());
            ServiceLocator.Register<IUtils>(new Utils());
            ServiceLocator.Register<IIndexesInitializer>(new IndexesInitializer());

            SetupDebugServices();

            gameStateMachine.Enter<BootstrapState>();
        }

        private static void SetupDebugServices()
        {
#if DEBUG
            ServiceLocator.Register<IDebug>(new SimpleDebug());
#else
            ServiceLocator.Setup<IDebug>(new DebugMock());
#endif
        }

        private static void InitializeEcs()
        {
            Contexts.Instance.InitializeScope<Game>();
            Contexts.Instance.InitializeScope<Scopes.Cheats>();
            Contexts.Instance.InitializeScope<Scopes.Input>();
        }
    }
}
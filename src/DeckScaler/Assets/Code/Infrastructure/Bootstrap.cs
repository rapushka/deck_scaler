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

            ServiceLocator.Setup<IUI>(new UI());
            ServiceLocator.Setup<ICameras>(new Cameras(_servicesData));
            ServiceLocator.Setup<IGameStateMachine>(gameStateMachine);
            ServiceLocator.Setup<IEcs>(new Ecs());
            ServiceLocator.Setup<IConfigs>(_servicesData.Configs);
            ServiceLocator.Setup<IProgress>(new Progress());
            ServiceLocator.Setup<IFactories>(new Factories());
            ServiceLocator.Setup<IRandom>(new SimpleRandom());
            ServiceLocator.Setup<IUiMediator>(new UiMediator());
            ServiceLocator.Setup<ITime>(new SimpleTime());
            ServiceLocator.Setup<IInput>(new UnityInput());
            ServiceLocator.Setup<IUtils>(new Utils());
            ServiceLocator.Setup<IIndexesInitializer>(new IndexesInitializer());

            SetupDebugServices();

            gameStateMachine.Enter<BootstrapState>();
        }

        private static void SetupDebugServices()
        {
#if DEBUG
            ServiceLocator.Setup<IDebug>(new SimpleDebug());
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
using DeckScaler.Service;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Services.Data _servicesData;

        private void Awake()
        {
            InitializeEcs();

            var gameStateMachine = new GameStateMachine();

            Services.Setup<IUI>(new UI());
            Services.Setup<ICameras>(new Cameras(_servicesData));
            Services.Setup<IGameStateMachine>(gameStateMachine);
            Services.Setup<IEcs>(new Ecs());
            Services.Setup<IConfigs>(_servicesData.Configs);
            Services.Setup<IProgress>(new Progress());
            Services.Setup<IFactories>(new Factories());
            Services.Setup<IRandom>(new SimpleRandom());
            Services.Setup<IUiMediator>(new UiMediator());
            Services.Setup<ITime>(new SimpleTime());

            SetupDebugServices();

            gameStateMachine.Enter<BootstrapState>();
        }

        private static void SetupDebugServices()
        {
#if DEBUG
            Services.Setup<IDebug>(new SimpleDebug());
#else
            Services.Setup<IDebug>(new DebugMock());
#endif
        }

        private static void InitializeEcs()
        {
            Contexts.Instance.InitializeScope<Game>();
            Contexts.Instance.InitializeScope<Cheats>();
        }
    }
}
using DeckScaler.Service;
using UnityEngine;

namespace DeckScaler
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Cameras.Data _cameras;
        [SerializeField] private Configs _configs;

        private void Awake()
        {
            var gameStateMachine = new GameStateMachine();
            Services.Init
            (
                new Services.Data
                {
                    StateMachine = gameStateMachine,
                    CamerasData = _cameras,
                    Configs = _configs,
                }
            );

            gameStateMachine.Enter<States.BootstrapState>();
        }
    }
}
using UnityEngine;

namespace DeckScaler
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Services.Data _servicesData;

        private void Awake()
        {
            var gameStateMachine = new GameStateMachine();
            Services.Init(gameStateMachine, _servicesData);

            gameStateMachine.Enter<DeckScaler.BootstrapState>();
        }
    }
}
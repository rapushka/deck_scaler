using DeckScaler.Service;

namespace DeckScaler
{
    public class GameRunner
    {
        private readonly IConfigs _configs;

        public GameRunner(IConfigs configs)
            => _configs = configs;

        public void StartGame()
        {
            IGameStateMachine stateMachine = new GameStateMachine();
            ServiceLocator.Register(stateMachine);

            stateMachine.Enter<InitializeServicesState, IConfigs>(_configs);
        }
    }
}
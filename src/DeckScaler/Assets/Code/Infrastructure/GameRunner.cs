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
            var stateMachine = new GameStateMachine();
            ServiceLocator.Register<IGameStateMachine>(stateMachine);

            stateMachine.Enter<InitializeServicesState, IConfigs>(_configs);
        }
    }
}
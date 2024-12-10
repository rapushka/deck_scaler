using DeckScaler.Service;

namespace DeckScaler
{
    public class GameplayState : GameState
    {
        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        private static IEcs Ecs => ServiceLocator.Resolve<IEcs>();

        public override void Enter()
        {
            UiMediator.OpenScreen<GameplayHUD>();
        }

        public override void Exit()
        {
            Ecs.Dispose();
        }
    }
}
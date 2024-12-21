using Cysharp.Threading.Tasks;
using DeckScaler.Service;

namespace DeckScaler
{
    public class GameplayState : GameState
    {
        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        private static IEcs Ecs => ServiceLocator.Resolve<IEcs>();

        private static IUtils Utils => ServiceLocator.Resolve<IUtils>();

        public override void Enter()
        {
            Utils.Initialize();
            UiMediator.OpenScreen<GameplayHUD>();

            Ecs.StartGameplay();
        }

        public override UniTask Update()
        {
            Ecs.Update();
            return UniTask.CompletedTask;
        }

        public override void Exit()
        {
            UiMediator.DisposeCurrentScreen();

            Ecs.EndGameplay();
            Utils.Dispose();
        }
    }
}
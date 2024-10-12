using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler.States
{
    public class StartGameState : GameState
    {
        public override void Enter()
        {
            Services.Instance.Ecs.Init();

            SpawnInitials();

            Services.Instance.UI.ShowGameplayHUD();
            StateMachine.Enter<GameplayState>();
        }

        private void SpawnInitials()
        {
            Contexts.Instance.Scope().CreateEntity()
                    .Add<Name, string>("Test Lead")
                    .Is<Lead>(true);
        }
    }
}
using DeckScaler.Component;
using DeckScaler.Service;
using Entitas.Generic;

namespace DeckScaler.States
{
    public class StartGameState : GameState
    {
        public override void Enter()
        {
            Services.Get<Ecs>().Init();

            SpawnInitials();

            Services.Get<UI>().ShowGameplayHUD();
            StateMachine.Enter<GameplayState>();
        }

        private void SpawnInitials()
        {
            var unitsUnitViewPrefab = Services.Get<Configs>().Units.UnitViewPrefab;

            Contexts.Instance.Scope().CreateEntity()
                    .Add<Name, string>("Test Lead")
                    .Is<Lead>(true);
        }
    }
}
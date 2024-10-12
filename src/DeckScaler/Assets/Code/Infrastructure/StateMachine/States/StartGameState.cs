using DeckScaler.Component;
using DeckScaler.Service;
using DeckScaler.Utils;

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
            var unitsConfig = Services.Get<Configs>().Units;
            var config = unitsConfig.UnitConfigs["bouncer"];

            unitsConfig.UnitViewPrefab
                       .Spawn()
                       .Entity
                       .Add<Name, string>("Test Lead")
                       .Is<Lead>(true)
                       .Add<Component.Suit, Suit>(config.Suit)
                ;
        }
    }
}
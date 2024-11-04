using DeckScaler.Component;
using DeckScaler.Service;

namespace DeckScaler.States
{
    public class LoadCurrentStageState : GameState
    {
        public override void Enter()
        {
            var progress = Services.Get<Progress>().CurrentProgress;
            Services.Get<EventBus>().Send<SpawnUnit, SpawnUnit.Args>(new(progress.SelectedLeadID, UnitType.Lead));
            // Services.Get<Factories>().Lead.Create(progress.SelectedLeadID);

            StateMachine.Enter<GameplayState>();
        }
    }
}
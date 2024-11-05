using DeckScaler.Component;
using DeckScaler.Service;

namespace DeckScaler.States
{
    public class LoadCurrentStageState : GameState
    {
        public override void Enter()
        {
            var progress = Services.Get<Progress>().CurrentProgress;
            Services.Get<EventBus>().Send<SpawnUnit, (string, Side)>((progress.SelectedLeadID, Side.Player));

            StateMachine.Enter<GameplayState>();
        }
    }
}
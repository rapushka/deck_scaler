using DeckScaler.Component;
using DeckScaler.Service;

namespace DeckScaler
{
    public class LoadCurrentStageState : GameState
    {
        public override void Enter()
        {
            var progress = Services.Get<Progress>().CurrentProgress;
            Services.Get<EventBus>().Send<SpawnAlly, string>(progress.SelectedLeadID);

            StateMachine.Enter<GameplayState>();
        }
    }
}
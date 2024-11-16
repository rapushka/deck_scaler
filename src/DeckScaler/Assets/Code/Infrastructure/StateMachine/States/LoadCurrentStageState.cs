using DeckScaler.Service;

namespace DeckScaler
{
    public class LoadCurrentStageState : GameState
    {
        private static UnitFactory UnitFactory => Services.Get<Factories>().Unit;

        public override void Enter()
        {
            var progress = Services.Get<Progress>().CurrentRun;
            UnitFactory.CreateTeammate(progress.SelectedLeadID);

            StateMachine.Enter<GameplayState>();
        }
    }
}
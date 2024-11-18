using DeckScaler.Service;

namespace DeckScaler
{
    public class LoadCurrentStageState : GameState
    {
        private static UnitFactory UnitFactory => Services.Get<IFactories>().Unit;

        public override void Enter()
        {
            var progress = Services.Get<IProgress>().CurrentRun;
            UnitFactory.CreateTeammate(progress.SelectedLeadID);

            StateMachine.Enter<GameplayState>();
        }
    }
}
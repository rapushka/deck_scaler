using DeckScaler.Service;
using Entitas;

namespace DeckScaler
{
    public class SpawnPlayerTeamFromProgress : IInitializeSystem
    {
        private static UnitFactory UnitFactory => Services.Get<IFactories>().Unit;

        public void Initialize()
        {
            var progress = Services.Get<IProgress>().CurrentRun;
            UnitFactory.CreateTeammate(progress.SelectedLeadID);
        }
    }
}
using DeckScaler.Service;
using Entitas;

namespace DeckScaler
{
    public class SpawnPlayerTeamFromProgress : IInitializeSystem
    {
        private static IUnitFactory Factory => Services.Get<IFactories>().Unit;

        private static ProgressData Progress => Services.Get<IProgress>().CurrentRun;

        public void Initialize()
        {
            foreach (var unitID in Progress.TeammateIDs)
                Factory.CreateTeammate(unitID.Value);
        }
    }
}
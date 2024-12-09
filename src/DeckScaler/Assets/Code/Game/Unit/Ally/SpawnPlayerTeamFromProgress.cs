using DeckScaler.Service;
using Entitas;

namespace DeckScaler
{
    public class SpawnPlayerTeamFromProgress : IInitializeSystem
    {
        private static IUnitFactory Factory => ServiceLocator.Get<IFactories>().Unit;

        private static ProgressData Progress => ServiceLocator.Get<IProgress>().CurrentRun;

        public void Initialize()
        {
            foreach (var unitID in Progress.TeammateIDs)
                Factory.CreateTeammate(unitID.Value);
        }
    }
}
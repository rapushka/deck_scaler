using DeckScaler.Service;
using Entitas;

namespace DeckScaler
{
    public class SpawnPlayerTeamFromProgress : IInitializeSystem
    {
        private static IUnitFactory Factory => ServiceLocator.Resolve<IFactories>().Unit;

        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        public void Initialize()
        {
            foreach (var unitID in Progress.TeammateIDs)
                Factory.CreateTeammate(unitID.Value);
        }
    }
}
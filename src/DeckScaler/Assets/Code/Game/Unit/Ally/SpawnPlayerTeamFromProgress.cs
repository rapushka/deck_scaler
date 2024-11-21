using DeckScaler.Service;
using Entitas;

namespace DeckScaler
{
    public class SpawnPlayerTeamFromProgress : IInitializeSystem
    {
        private static IFactories Factory => Services.Get<IFactories>();

        private static ProgressData Progress => Services.Get<IProgress>().CurrentRun;

        public void Initialize()
        {
            foreach (var unitID in Progress.TeammateIDs)
                Factory.CreateTeammate(unitID.Value);
        }
    }
}
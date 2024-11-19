using DeckScaler.Service;
using Entitas;

namespace DeckScaler
{
    public class SpawnPlayerTeamFromProgress : IInitializeSystem
    {
        private static IFactories Factory => Services.Get<IFactories>();

        public void Initialize()
        {
            var progress = Services.Get<IProgress>().CurrentRun;
            Factory.CreateTeammate(progress.SelectedLeadID);
        }
    }
}
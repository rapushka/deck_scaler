using DeckScaler.Service;
using Entitas;

namespace DeckScaler.Systems
{
    public class SpawnTrinketsFromProgress : IInitializeSystem
    {
        private static ITrinketFactory Factory => ServiceLocator.Resolve<IFactories>().Trinkets;

        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        public void Initialize()
        {
            foreach (var trinketID in Progress.Trinkets)
                Factory.CreateInPlayerInventory(trinketID);
        }
    }
}
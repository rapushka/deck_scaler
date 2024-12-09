using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;

namespace DeckScaler.Systems
{
    public sealed class LoadPlayerInventoryFromProgress : IInitializeSystem
    {
        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        public void Initialize()
        {
            CreateEntity.Empty()
                .Add<DebugName, string>("player inventory")
                .Add<PlayerInventory>()
                .Add<Gold, int>(Progress.Gold)
                ;
        }
    }
}
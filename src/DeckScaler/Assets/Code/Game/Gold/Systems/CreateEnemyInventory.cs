using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;

namespace DeckScaler.Systems
{
    public sealed class CreateEnemyInventory : IInitializeSystem
    {
        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        public void Initialize()
        {
            CreateEntity.Empty()
                .Add<DebugName, string>("enemy's inventory")
                .Add<Inventory, Side>(Side.Enemy)
                .Add<Money, int>(Progress.EnemyGold)
                ;
        }
    }
}
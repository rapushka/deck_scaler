using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class LoadPlayerInventoryFromProgress : IInitializeSystem
    {
        private readonly IGroup<Entity<Game>> _inventories
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<PlayerInventory>()
                    .Build()
            );

        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        public void Initialize()
        {
            foreach (var inventory in _inventories)
            {
                inventory
                    .Add<Inventory, Side>(Side.Player)
                    .Add<Gold, int>(Progress.Gold)
                    ;
            }
        }
    }
}
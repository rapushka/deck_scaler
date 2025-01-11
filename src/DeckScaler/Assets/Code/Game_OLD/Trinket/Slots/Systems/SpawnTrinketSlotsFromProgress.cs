using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;

namespace DeckScaler
{
    public sealed class SpawnTrinketSlotsFromProgress : IInitializeSystem
    {
        private static ITrinketFactory Factory => ServiceLocator.Resolve<IFactories>().Trinkets;

        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        public void Initialize()
        {
            for (var i = 0; i < Progress.TrinketSlotCount; i++)
                Factory.CreateTrinketSlot(i);

            CreateEntity.OneFrame()
                .Add<RearrangeTrinketSlots>()
                ;
        }
    }
}
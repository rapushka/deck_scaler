using DeckScaler.Component;

namespace DeckScaler
{
    public sealed class GameplayFeature : Feature
    {
        public GameplayFeature()
            : base(nameof(GameplayFeature))
        {
            Add(new UnitsFeature());

            // # Cleanup
            Add(new RemoveComponentSystem<Initialized>());
            Add(new ProcessInitializationSystem());

            Add(new DestroyEntityBehavioursSystem());

            Add(new DestroyGameEntitiesSystem());
            Add(new DestroyInputEntitiesSystem());
        }
    }
}
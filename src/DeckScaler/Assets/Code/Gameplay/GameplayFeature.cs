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
            Add(new RemoveComponent<Initialized>());
            Add(new ProcessInitialization());

            Add(new DestroyEntityBehavioursSystem());

            Add(new DestroyGameEntitiesSystem());
            Add(new DestroyInputEntitiesSystem());
        }
    }
}
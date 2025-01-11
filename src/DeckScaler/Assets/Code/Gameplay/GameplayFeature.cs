using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class GameplayFeature : Feature
    {
        public GameplayFeature()
            : base(nameof(GameplayFeature))
        {
            Add(new DestroyEntityBehaviours());

            Add(new DestroyGameEntities());
            Add(new DestroyInputEntities());
        }
    }
}
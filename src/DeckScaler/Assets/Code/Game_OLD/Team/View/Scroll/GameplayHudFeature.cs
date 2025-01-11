using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class GameplayHudFeature : Feature
    {
        public GameplayHudFeature()
            : base(nameof(GameplayHudFeature))
        {
            Add(new RegisterGameplayHudEntities());
        }
    }
}
using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class GameOverFeature : Feature
    {
        public GameOverFeature()
        {
            Add(new GameOverIfAllyDied());
        }
    }
}
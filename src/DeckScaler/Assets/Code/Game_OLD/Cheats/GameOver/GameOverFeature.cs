using DeckScaler.Cheats.Systems;

namespace DeckScaler.Cheats
{
    public sealed class GameOverFeature : Feature
    {
        public GameOverFeature()
            : base(nameof(GameOverFeature))
        {
            Add(new ParseGameOver());
            Add(new ProcessGameOverCheat());
        }
    }
}
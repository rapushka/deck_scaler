using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class GameOverFeature : Feature
    {
        public GameOverFeature()
        {
            Add(new IfAllyDiedStartGameOverTimer());
            Add(new OnGameOverTimerElapsed());
        }
    }
}